using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Threading;
using LPReplayCore.Common;
using LPReplayCore.UIA;
using LPReplayCore;
using LAPResources;
using LPCommon;
using LPSpy.UIA;
using LPUIAObjects;
using Point = System.Windows.Point;

namespace LPSpy
{
    #region event handler arguments
    public class ElementsBuilderEventArgs : EventArgs
    {
        private List<AutomationElement> _ancestorElements = null;
        private List<AutomationElement> _childElements = null;
        private AutomationElement _element = null;
        private ElementsBuilder _elementBuilder = null;


        public ElementsBuilderEventArgs(
                        ElementsBuilder elementBuilder,
                        List<AutomationElement> ancestorElements,
                        List<AutomationElement> childElements,
                       AutomationElement element)
        {
            _elementBuilder = elementBuilder;
            _ancestorElements = ancestorElements;
            _childElements = childElements;
            _element = element;
        }

        public List<AutomationElement> ancestorElements
        {
            get { return _ancestorElements; }
        }

        public List<AutomationElement> childElements
        {
            get { return _childElements; }
        }

        public AutomationElement element
        {
            get { return _element; }
        }

        public ElementsBuilder elementBuilder
        {
            get { return _elementBuilder; }
        }
    }
    #endregion
    

    public class ElementsBuilder
    {
        #region private properties
        private List<AutomationElement> _ancestorElements = new List<AutomationElement>();
        private List<AutomationElement> _childElements = new List<AutomationElement>();
        private AutomationElement _element = null;
        private static AndCondition _menuCondition = new AndCondition(new NotCondition(new PropertyCondition(AutomationElement.NameProperty, string.Empty)),
                                                                                                               new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
        private static PropertyCondition _propertyMenuItemCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem);
        public delegate void ElementsBuilderEventHandler(object source, ElementsBuilderEventArgs args);
        public event ElementsBuilderEventHandler afterPointToElementsEventHander = null;
        public event ElementsBuilderEventHandler afterReNewElementsByChildEventHander = null;
        public event ElementsBuilderEventHandler afterReNewElementsByAncestorEventHander = null;
        private CacheRequest _generalCacheReq = null;
        #endregion

        public ElementsBuilder()
        {
            if (_generalCacheReq == null)
            {
                _generalCacheReq = new CacheRequest();
                _generalCacheReq.Add(AutomationElement.BoundingRectangleProperty);
                _generalCacheReq.Add(AutomationElement.ControlTypeProperty);
                _generalCacheReq.Add(AutomationElement.NameProperty);
            }
        }

        #region private methods
        //try to retrieve the menu element
        private AutomationElement RetrieveMenuElement(AutomationElement element)
        {
            AndCondition andCondition = new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu),
                new PropertyCondition(AutomationElement.NameProperty, element.Cached.Name));
            AutomationElement ae = null;
           using( _generalCacheReq.Activate())
            {
                ae = element.FindFirst(TreeScope.Descendants, andCondition);
            }
            
            if (ae != null)
                return ae;

            Condition menuname = new PropertyCondition(AutomationElement.NameProperty, element.Current.Name);
            Condition menuprocessid = new PropertyCondition(AutomationElement.ProcessIdProperty, element.Current.ProcessId);
            Condition menutypecondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu);
            Condition andcondition = new AndCondition(new Condition[] { menutypecondtion, menuname, menuprocessid });
            try
            {
                using (_generalCacheReq.Activate())
                {
                    ae = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andcondition);
                }
                if (ae != null)
                {
                    return ae;
                }
            }
            catch { }
            return null;
        }

        private AutomationElement getChildMenuItemByNameType(AutomationElement parent, string menuName)
        {
            using (_generalCacheReq.Activate())
            {
                return parent.FindFirst(TreeScope.Children, new AndCondition(new PropertyCondition(AutomationElement.NameProperty, menuName),
                     new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem)));
            }
        }
        #endregion

        public void RenewElementsByChild(AutomationElement element)
        {
            AutomationElementCollection aeCollection = null;
            AutomationElement menuItemAe = null;
            AutomationElement menuAe = null;
            int indexofAncestor = 0;
            int AncestorCount = this._ancestorElements.Count;
            for (indexofAncestor = 0; indexofAncestor < AncestorCount; ++indexofAncestor)
            {
                if (_ancestorElements[indexofAncestor].Cached.ControlType == ControlType.MenuItem)
                {
                    menuItemAe = _ancestorElements[indexofAncestor];
                    using (_generalCacheReq.Activate())
                    {
                        if (UIAUtility.ExpandMenuItem(menuItemAe) && menuItemAe.FindFirst(TreeScope.Children, _propertyMenuItemCondition) == null)
                        {
                            menuAe = RetrieveMenuElement(menuItemAe);
                            if (menuAe != null)
                            {
                                if (indexofAncestor + 1 < AncestorCount)
                                    _ancestorElements[indexofAncestor + 1] = getChildMenuItemByNameType(menuAe,  _ancestorElements[indexofAncestor + 1].Cached.Name);
                                else
                                    element = getChildMenuItemByNameType(menuAe, element.Cached.Name);
                            }
                            else
                                Console.WriteLine("not find menu element {0}", menuItemAe.Cached.Name);
                        }
                    }
                }
            }

            //
            using (_generalCacheReq.Activate())
            {
                menuAe = null;
                if (element.Cached.ControlType == ControlType.MenuItem)
                {
                    if (UIAUtility.ExpandMenuItem(element))
                    {
                        if (element.FindFirst(TreeScope.Children, _propertyMenuItemCondition) == null)
                            menuAe = RetrieveMenuElement(element);
                    }
                    else
                    {
                        Console.WriteLine("no child element - nothing is changed, childrenelement count {0}, ancestorelement count {1}", _childElements.Count, _ancestorElements.Count);
                        return;
                    }
                }

                if (menuAe != null)
                {
                    aeCollection = menuAe.FindAll(TreeScope.Descendants, _menuCondition);
                }
                else
                {
                    if ( element.Current.ControlType == ControlType.MenuItem)
                        aeCollection = element.FindAll(TreeScope.Descendants, _menuCondition);
                    else
                        aeCollection = element.FindAll(TreeScope.Children, Condition.TrueCondition);
                }
                
                if ( aeCollection != null && aeCollection.Count > 0)
                {
                    this._element = element;
                    _childElements.Clear();
                    _childElements = aeCollection.Cast<AutomationElement>().ToList();
                    _ancestorElements.Add(element);
                }
                else
                {
                    Console.WriteLine("no child element - nothing is changed, childrenelement count {0}, ancestorelement count {1}", _childElements.Count, _ancestorElements.Count);
                    return;
                }
            }

            Console.WriteLine("childrenelement count {0}, ancestorelement count {1}", _childElements.Count, _ancestorElements.Count);
            if (null != afterReNewElementsByChildEventHander)
            {
                ElementsBuilderEventArgs e = new ElementsBuilderEventArgs(this, _ancestorElements, _childElements, _element);
                afterReNewElementsByChildEventHander(this, e);
            }
        }

        public void RenewElementsByAncestor(AutomationElement element)
        {
            int indexofAncestor = 0;
            int AncestorCount = this._ancestorElements.Count;
            AutomationElementCollection aeCollection = null;
            AutomationElement menuItemAe = null;
            AutomationElement menuAe = null;

            using (_generalCacheReq.Activate())
            {
                for (indexofAncestor = 0; indexofAncestor < AncestorCount; ++indexofAncestor)
                {
                    if (_ancestorElements[indexofAncestor].Cached.ControlType == ControlType.MenuItem)
                    {
                        menuItemAe = _ancestorElements[indexofAncestor];
                        using (_generalCacheReq.Activate())
                        {
                            if (UIAUtility.ExpandMenuItem(menuItemAe) && menuItemAe.FindFirst(TreeScope.Children, _propertyMenuItemCondition) == null)
                            {
                                menuAe = RetrieveMenuElement(menuItemAe);
                                if (menuAe != null)
                                {
                                    if (indexofAncestor + 1 < AncestorCount)
                                        _ancestorElements[indexofAncestor + 1] = getChildMenuItemByNameType(menuAe, _ancestorElements[indexofAncestor + 1].Cached.Name);
                                    else
                                        element = getChildMenuItemByNameType(menuAe, element.Cached.Name);
                                }
                                else
                                    Console.WriteLine("not find menu element {0}", menuItemAe.Cached.Name);
                            }
                        }
                    }
                    if (UIAUtility.AreEqual3(_ancestorElements[indexofAncestor], element)) //found
                    {
                        element = _ancestorElements[indexofAncestor];
                        break;
                    }
                }

                if (element.Current.ControlType == ControlType.MenuItem)
                    aeCollection = element.FindAll(TreeScope.Descendants, _menuCondition);
                else
                {
                    if (element.FindFirst(TreeScope.Children, Condition.TrueCondition) == null)
                    {
                        element = UIAUtility.GetParentElement(element);
                    }
                    aeCollection = element.FindAll(TreeScope.Children, Condition.TrueCondition);
                }
                _ancestorElements.Clear();
                _ancestorElements = UIAUtility.GetAutomationElementsLine(element);
                _childElements.Clear();
                _childElements = aeCollection.Cast<AutomationElement>().ToList();
                this._element = element;
            }
            Console.WriteLine("childrenelement count {0}, ancestorelement count {1}", _childElements.Count, _ancestorElements.Count);
            if (null != afterReNewElementsByAncestorEventHander)
            {
                ElementsBuilderEventArgs e = new ElementsBuilderEventArgs(this, _ancestorElements, _childElements, _element);
                afterReNewElementsByAncestorEventHander(this, e);
            }
        }

        public void PointToElements(Point point)
        {
            AutomationElementCollection aeCollection = null;
            AutomationElement menuAe = null;

            using (_generalCacheReq.Activate())
            {
                _element = AutomationElement.FromPoint(point);
                UIAHighlight.HighlightThread_Spy(_element);

                if (_element.Current.ControlType == ControlType.MenuItem)
                {
                    if (UIAUtility.ExpandMenuItem(_element) && _element.FindFirst(TreeScope.Children, _propertyMenuItemCondition) == null)
                        menuAe = RetrieveMenuElement(_element);
                }

                if (menuAe == null)
                {
                    if (_element.FindFirst(TreeScope.Children, Condition.TrueCondition) == null)
                        _element = TreeWalker.ControlViewWalker.GetParent(_element);
                    aeCollection = _element.FindAll(TreeScope.Children, Condition.TrueCondition);
                }
                else
                {
                    aeCollection = menuAe.FindAll(TreeScope.Descendants, _menuCondition);
                }
                _ancestorElements.Clear();
                _ancestorElements = UIAUtility.GetAutomationElementsLine(_element);
                _childElements.Clear();
                _childElements = aeCollection.Cast<AutomationElement>().ToList();
            }
            Console.WriteLine("childrenelement count {0}, ancestorelement count {1}", _childElements.Count, _ancestorElements.Count);
            if (null != afterPointToElementsEventHander)
            {
                ElementsBuilderEventArgs e = new ElementsBuilderEventArgs(this, _ancestorElements, _childElements, _element);
                afterPointToElementsEventHander(this, e);
            }
        }
    }
}
