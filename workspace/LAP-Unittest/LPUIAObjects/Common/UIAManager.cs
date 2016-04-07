using LPReplayCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPUIAObjects
{
    public class UIAManager
    {
        protected UIAManager()
        {
        }

        public void Initialize(string pathToModel)
        {
            AppModel.Initialize(pathToModel);
        }

        public static UIAModel GetManager(string pathToModel)
        {
            AppModel model = AppModelManager.Load(pathToModel);
            return new UIAModel(model);
        }
        
        /*
        public static UIAWindow UIAWindow(string conditionString)
        {
            UIACondition condition = UIACondition.GetCondition(conditionString);
            UIAWindow window = new UIAWindow(condition);
            return window;
        }*/

        public static UIAWindow UIAWindow(string conditionString)
        {
            return Get<UIAWindow>(conditionString);
        }

        public static UIAButton UIAButton(string conditionString)
        {
            return Get<UIAButton>(conditionString);
        }

        public static UIACheckbox UIACheckbox(string conditionString)
        {
            return Get<UIACheckbox>(conditionString);
        }

        public static UIAComboBox UIAComboBox(string conditionString)
        {
            return Get<UIAComboBox>(conditionString);
        }

        public static UIAEdit UIAEdit(string conditionString)
        {
            return Get<UIAEdit>(conditionString);
        }

        public static UIAEditor UIAEditor(string conditionString)
        {
            return Get<UIAEditor>(conditionString);
        }

        public static UIAImage UIAImage(string conditionString)
        {
            return Get<UIAImage>(conditionString);
        }

        public static UIALink UIALink(string conditionString)
        {
            return Get<UIALink>(conditionString);
        }

        public static UIAList UIAList(string conditionString)
        {
            return Get<UIAList>(conditionString);
        }

        public static UIAMenu UIAMenu(string conditionString)
        {
            return Get<UIAMenu>(conditionString);
        }

        public static UIAMenuBar UIAMenuBar(string conditionString)
        {
            return Get<UIAMenuBar>(conditionString);
        }

        public static UIACustom UIAObject(string conditionString)
        {
            return Get<UIACustom>(conditionString);
        }

        public static UIAPane UIAPane(string conditionString)
        {
            return Get<UIAPane>(conditionString);
        }

        public static UIARadioButton UIARadioButton(string conditionString)
        {
            return Get<UIARadioButton>(conditionString);
        }

        public static UIAScrollBar UIAScrollBar(string conditionString)
        {
            return Get<UIAScrollBar>(conditionString);
        }

        public static UIASlider UIASlider(string conditionString)
        {
            return Get<UIASlider>(conditionString);
        }

        public static UIATab UIATab(string conditionString)
        {
            return Get<UIATab>(conditionString);
        }

        public static UIATable UIATable(string conditionString)
        {
            return Get<UIATable>(conditionString);
        }

        public static UIAText UIAText(string conditionString)
        {
            return Get<UIAText>(conditionString);
        }

        public static UIAToolBar UIAToolBar(string conditionString)
        {
            return Get<UIAToolBar>(conditionString);
        }

        public static UIATree UIATree(string conditionString)
        {
            return UIAManager.Get<UIATree>(conditionString);
        }

        private static T Get<T>(string conditionString) where T: UIAControlBase, new()
        {
            return Get<T>(AppModel.Current, conditionString);
        }

        internal static T Get<T>(AppModel model, string conditionString) where T : UIAControlBase, new()
        {
            UIACondition condition = UIACondition.GetCondition(model, conditionString);
            T control = new T();
            ((UIAControlBase)control).SetCondition(condition);
            return control;
        }
    }

    public class UIAModel
    {
        protected AppModel _model;

        internal UIAModel(AppModel model)
        {
            _model = model;
        }

        public UIAWindow UIAWindow(string conditionString)
        {
            return Get<UIAWindow>(conditionString);
        }

        public UIAButton UIAButton(string conditionString)
        {
            return Get<UIAButton>(conditionString);
        }

        public UIACheckbox UIACheckbox(string conditionString)
        {
            return Get<UIACheckbox>(conditionString);
        }

        public UIAComboBox UIAComboBox(string conditionString)
        {
            return Get<UIAComboBox>(conditionString);
        }

        public UIAEdit UIAEdit(string conditionString)
        {
            return Get<UIAEdit>(conditionString);
        }

        public UIAEditor UIAEditor(string conditionString)
        {
            return Get<UIAEditor>(conditionString);
        }

        public UIAImage UIAImage(string conditionString)
        {
            return Get<UIAImage>(conditionString);
        }

        public UIALink UIALink(string conditionString)
        {
            return Get<UIALink>(conditionString);
        }

        public UIAList UIAList(string conditionString)
        {
            return Get<UIAList>(conditionString);
        }

        public UIAMenu UIAMenu(string conditionString)
        {
            return Get<UIAMenu>(conditionString);
        }

        public UIAMenuBar UIAMenuBar(string conditionString)
        {
            return Get<UIAMenuBar>(conditionString);
        }

        public UIACustom UIAObject(string conditionString)
        {
            return Get<UIACustom>(conditionString);
        }

        public UIAPane UIAPane(string conditionString)
        {
            return Get<UIAPane>(conditionString);
        }

        public UIARadioButton UIARadioButton(string conditionString)
        {
            return Get<UIARadioButton>(conditionString);
        }

        public UIAScrollBar UIAScrollBar(string conditionString)
        {
            return Get<UIAScrollBar>(conditionString);
        }

        public UIASlider UIASlider(string conditionString)
        {
            return Get<UIASlider>(conditionString);
        }

        public UIATab UIATab(string conditionString)
        {
            return Get<UIATab>(conditionString);
        }

        public UIATable UIATable(string conditionString)
        {
            return Get<UIATable>(conditionString);
        }

        public UIAText UIAText(string conditionString)
        {
            return Get<UIAText>(conditionString);
        }

        public UIAToolBar UIAToolBar(string conditionString)
        {
            return Get<UIAToolBar>(conditionString);
        }

        public UIATree UIATree(string conditionString)
        {
            return Get<UIATree>(conditionString);
        }


        protected T Get<T>(string conditionString) where T : UIAControlBase, new()
        {
            return UIAManager.Get<T>(_model, conditionString);
        }

    }
}
