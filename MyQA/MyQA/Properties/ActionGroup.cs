using System;
namespace MyQA.Properties
{
    public partial class ActionGroup : Gtk.ActionGroup
    {
        public ActionGroup() :
                base("MyQA.Properties.ActionGroup")
        {
            this.Build();
        }
    }
}
