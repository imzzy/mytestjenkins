using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace LAPResourceManager
{
    class MLUResManagerSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeDomObject) 
        {
            CodeDomSerializer baseSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(ResourceControl).BaseType, 
                typeof(CodeDomSerializer)); 
            return baseSerializer.Deserialize(manager, codeDomObject);
        }

        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            CodeDomSerializer baseSerializer =
                (CodeDomSerializer)manager.GetSerializer(typeof(ResourceControl).BaseType, typeof(CodeDomSerializer)); 
            object codeObject = baseSerializer.Serialize(manager, value);
          
            if (codeObject is CodeStatementCollection) 
            {
                CodeStatementCollection statements = (CodeStatementCollection)codeObject;

                statements.Insert(0, new CodeCommentStatement("MLUResManager is used to set the custom resource file which in the another resource.dll."));
                statements.Insert(0, new CodeCommentStatement("Must to set the BaseName property which is use to get the resource file name."));

                CodeExpression targetObject =
                   base.SerializeToExpression(manager, value);
                if (targetObject != null)
                {
                    CodeExpression Paramter = new CodeArgumentReferenceExpression("ref resources");
                    CodeMethodInvokeExpression methodCall =
                         new CodeMethodInvokeExpression(targetObject, "reInitResManger", Paramter);
                    statements.Add(methodCall);
                }
            }
            
            return codeObject; 
        }
        

    }
}
