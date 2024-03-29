
// This file has been generated by the GUI designer. Do not modify.
namespace MyQA.view
{
	public partial class OpeningScreen
	{
		private global::Gtk.Fixed fixed18;

		private global::Gtk.Image background;

		private global::Gtk.Image welcome;

		private global::Gtk.Button playBtn;

		private global::Gtk.Button historyBtn;

		private global::Gtk.Button exitBtn;

		private global::Gtk.Entry userName;

		private global::Gtk.Entry errorMsg;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget MyQA.view.OpeningScreen
			global::Stetic.BinContainer.Attach(this);
			this.WidthRequest = 800;
			this.HeightRequest = 600;
			this.Name = "MyQA.view.OpeningScreen";
			// Container child MyQA.view.OpeningScreen.Gtk.Container+ContainerChild
			this.fixed18 = new global::Gtk.Fixed();
			this.fixed18.Name = "fixed18";
			this.fixed18.HasWindow = false;
			// Container child fixed18.Gtk.Fixed+FixedChild
			this.background = new global::Gtk.Image();
			this.background.WidthRequest = 800;
			this.background.HeightRequest = 600;
			this.background.Name = "background";
			this.fixed18.Add(this.background);
			// Container child fixed18.Gtk.Fixed+FixedChild
			this.welcome = new global::Gtk.Image();
			this.welcome.WidthRequest = 500;
			this.welcome.HeightRequest = 100;
			this.welcome.Name = "welcome";
			this.fixed18.Add(this.welcome);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed18[this.welcome]));
			w2.X = 150;
			w2.Y = 150;
			// Container child fixed18.Gtk.Fixed+FixedChild
			this.playBtn = new global::Gtk.Button();
			this.playBtn.WidthRequest = 110;
			this.playBtn.HeightRequest = 50;
			this.playBtn.CanFocus = true;
			this.playBtn.Name = "playBtn";
			this.fixed18.Add(this.playBtn);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed18[this.playBtn]));
			w3.X = 200;
			w3.Y = 380;
			// Container child fixed18.Gtk.Fixed+FixedChild
			this.historyBtn = new global::Gtk.Button();
			this.historyBtn.WidthRequest = 110;
			this.historyBtn.HeightRequest = 50;
			this.historyBtn.CanFocus = true;
			this.historyBtn.Name = "historyBtn";
			this.fixed18.Add(this.historyBtn);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed18[this.historyBtn]));
			w4.X = 350;
			w4.Y = 380;
			// Container child fixed18.Gtk.Fixed+FixedChild
			this.exitBtn = new global::Gtk.Button();
			this.exitBtn.WidthRequest = 110;
			this.exitBtn.HeightRequest = 50;
			this.exitBtn.CanFocus = true;
			this.exitBtn.Name = "exitBtn";
			this.fixed18.Add(this.exitBtn);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed18[this.exitBtn]));
			w5.X = 500;
			w5.Y = 380;
			// Container child fixed18.Gtk.Fixed+FixedChild
			this.userName = new global::Gtk.Entry();
			this.userName.WidthRequest = 410;
			this.userName.HeightRequest = 40;
			this.userName.CanFocus = true;
			this.userName.Name = "userName";
			this.userName.IsEditable = true;
			this.userName.HasFrame = false;
			this.userName.InvisibleChar = '●';
			this.fixed18.Add(this.userName);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed18[this.userName]));
			w6.X = 200;
			w6.Y = 310;
			// Container child fixed18.Gtk.Fixed+FixedChild
			this.errorMsg = new global::Gtk.Entry();
			this.errorMsg.WidthRequest = 410;
			this.errorMsg.HeightRequest = 30;
			this.errorMsg.Name = "errorMsg";
			this.errorMsg.IsEditable = false;
			this.errorMsg.HasFrame = false;
			this.errorMsg.InvisibleChar = '●';
			this.errorMsg.Xalign = 0.5F;
			this.fixed18.Add(this.errorMsg);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed18[this.errorMsg]));
			w7.X = 200;
			w7.Y = 275;
			this.Add(this.fixed18);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.playBtn.Clicked += new global::System.EventHandler(this.ClickToPlay);
			this.historyBtn.Clicked += new global::System.EventHandler(this.ClickToHistory);
			this.exitBtn.Clicked += new global::System.EventHandler(this.ClickExit);
		}
	}
}
