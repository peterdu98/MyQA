
// This file has been generated by the GUI designer. Do not modify.
namespace MyQA.view
{
	public partial class HistoryScreen
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action KAction;

		private global::Gtk.Action kAction;

		private global::Gtk.Fixed fixed2;

		private global::Gtk.Image background;

		private global::Gtk.Button backBtn;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget MyQA.view.HistoryScreen
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach(this);
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup("Default");
			this.KAction = new global::Gtk.Action("KAction", global::Mono.Unix.Catalog.GetString("K"), null, null);
			this.KAction.ShortLabel = global::Mono.Unix.Catalog.GetString("K");
			w2.Add(this.KAction, null);
			this.kAction = new global::Gtk.Action("kAction", global::Mono.Unix.Catalog.GetString("k"), null, null);
			this.kAction.ShortLabel = global::Mono.Unix.Catalog.GetString("k");
			w2.Add(this.kAction, null);
			this.UIManager.InsertActionGroup(w2, 0);
			this.WidthRequest = 800;
			this.HeightRequest = 600;
			this.Name = "MyQA.view.HistoryScreen";
			// Container child MyQA.view.HistoryScreen.Gtk.Container+ContainerChild
			this.fixed2 = new global::Gtk.Fixed();
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.background = new global::Gtk.Image();
			this.background.WidthRequest = 800;
			this.background.HeightRequest = 600;
			this.background.Name = "background";
			this.fixed2.Add(this.background);
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.backBtn = new global::Gtk.Button();
			this.backBtn.WidthRequest = 110;
			this.backBtn.HeightRequest = 50;
			this.backBtn.Name = "backBtn";
			this.fixed2.Add(this.backBtn);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.backBtn]));
			w4.X = 350;
			w4.Y = 450;
			this.Add(this.fixed2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			w1.SetUiManager(UIManager);
			this.Hide();
			this.backBtn.Clicked += new global::System.EventHandler(this.ClickToBack);
		}
	}
}