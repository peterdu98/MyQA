
// This file has been generated by the GUI designer. Do not modify.
namespace MyQA.view
{
	public partial class LevelScreen
	{
		private global::Gtk.Fixed fixed2;

		private global::Gtk.Image background;

		private global::Gtk.Button easyBtn;

		private global::Gtk.Button mediumBtn;

		private global::Gtk.Button hardBtn;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget MyQA.view.LevelScreen
			global::Stetic.BinContainer.Attach(this);
			this.WidthRequest = 800;
			this.HeightRequest = 600;
			this.Name = "MyQA.view.LevelScreen";
			// Container child MyQA.view.LevelScreen.Gtk.Container+ContainerChild
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
			this.easyBtn = new global::Gtk.Button();
			this.easyBtn.WidthRequest = 110;
			this.easyBtn.HeightRequest = 50;
			this.easyBtn.CanFocus = true;
			this.easyBtn.Name = "easyBtn";
			this.fixed2.Add(this.easyBtn);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.easyBtn]));
			w2.X = 200;
			w2.Y = 350;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.mediumBtn = new global::Gtk.Button();
			this.mediumBtn.WidthRequest = 110;
			this.mediumBtn.HeightRequest = 50;
			this.mediumBtn.CanFocus = true;
			this.mediumBtn.Name = "mediumBtn";
			this.fixed2.Add(this.mediumBtn);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.mediumBtn]));
			w3.X = 350;
			w3.Y = 350;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.hardBtn = new global::Gtk.Button();
			this.hardBtn.WidthRequest = 110;
			this.hardBtn.HeightRequest = 50;
			this.hardBtn.CanFocus = true;
			this.hardBtn.Name = "hardBtn";
			this.fixed2.Add(this.hardBtn);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.hardBtn]));
			w4.X = 500;
			w4.Y = 350;
			this.Add(this.fixed2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.easyBtn.Clicked += new global::System.EventHandler(this.ClickToEasy);
			this.mediumBtn.Clicked += new global::System.EventHandler(this.ClickToMedium);
			this.hardBtn.Clicked += new global::System.EventHandler(this.ClickToHard);
		}
	}
}
