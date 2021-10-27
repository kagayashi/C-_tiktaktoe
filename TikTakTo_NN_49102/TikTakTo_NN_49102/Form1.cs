using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TikTakTo_NN_49102
{
	public partial class Form1 : Form
	{
		bool krok = true;// dla X - true dla O - false
		int ilośćKroków = 0;
		bool symbol;
		bool znalazlem = false;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button_click(object sender, EventArgs e)
		{
			ilośćKroków++;
			Button b = (Button)sender;
			if (krok)
			{
				b.Text = "X";
				b.BackColor = Color.Red;
			}
				
			else
			{
				b.Text = "O";
				b.BackColor = Color.Green;
				
			}
			

			krok = !krok;
			Sprawdz();
			if (krok != symbol)
			  Komputerchodzi(szukaKomputer());
			b.Enabled = false;
			
			
			
		}
		 private void Sprawdz()
		{
			bool wygrywa = false;

			//sprawdzamy poziomy 
			if ((b11.Text == b12.Text) && (b12.Text == b13.Text) && (b11.Text == "X" || b11.Text == "O"))
				wygrywa = true;
			else if ((b21.Text == b22.Text) && (b22.Text == b23.Text) && (b21.Text == "X" || b21.Text == "O"))
				wygrywa = true;
			else if ((b31.Text == b32.Text) && (b32.Text == b33.Text) && (b31.Text == "X" || b31.Text == "O"))
				wygrywa = true;

			//sprawdzamy pionowo
			else if((b11.Text == b21.Text) && (b21.Text == b31.Text) && (b11.Text == "X" || b11.Text == "O"))
				wygrywa = true;
			else if ((b12.Text == b22.Text) && (b22.Text == b32.Text) && (b12.Text == "X" || b12.Text == "O"))
				wygrywa = true;
			else if ((b13.Text == b23.Text) && (b23.Text == b33.Text) && (b13.Text == "X" || b13.Text == "O"))
				wygrywa = true;

			//sprawdzamy przekątna;
			else if((b11.Text == b22.Text) && (b22.Text == b33.Text) && (b11.Text == "X" || b11.Text == "O"))
				wygrywa = true;
			else if ((b13.Text == b22.Text) && (b22.Text == b31.Text) && (b13.Text == "X" || b13.Text == "O"))
				wygrywa = true;
			


			if (wygrywa)
			{
				disablebuttons();
				string winner = "";
				if (krok)
					winner = "O";
				else
					winner = "X";
				MessageBox.Show(winner + "  wygrywa ");
			}
			else
			{
				if (ilośćKroków == 9)
					MessageBox.Show(" remis ");

			}
				

		}
		private void disablebuttons()
		{

			foreach (Component c in Controls)
			{
				if (c.GetType() == typeof(Button))
				{
					Button b = (Button)c;
					b.Enabled = false;
					Reset.Enabled = true;
				}
			}
		
		}

		private void Reset_Click(object sender, EventArgs e)
		{
			foreach (Component c in Controls)
			{
				if (c.GetType() == typeof(Button))
				{
					Button b = (Button)c;
					b.BackColor = Color.FromKnownColor(KnownColor.Control);
					b.Enabled = false;
					b.Text = "";
				}
			}
				Reset.Text = "Reset";
				krok = true;
				ilośćKroków = 0;
				grazaO.Enabled = true;
				grazaX.Enabled = true;
				Reset.Enabled = false;
				grazaX.Text = "Gracz za X";
				grazaO.Text = "Gracz za O";

			
		}
		private void Komputerchodzi(in Button But)
		{
			string symbolKomputera, symbolgracza;
			
			if (symbol)
			{
				symbolKomputera = "O";
				symbolgracza = "X";
			}
			else
			{
				symbolKomputera = "X";
				symbolgracza = "O";
			}
			

			if (SprawdżCzyKtośWygra(symbolgracza))
				label_chat.Text = "O nie! Wygrasz w następnym ruchu";
			if (ilośćKroków < 9)
				But.PerformClick();
			if (SprawdżCzyKtośWygra(symbolKomputera))
				label_chat.Text = "Ha Ha ,W następnym ruchu wygram";



		}
		private Button szukaKomputer()
		{
			int i;
			Button knopka = new Button();
			Random rnd = new Random();
			Button[] arraybut = {b11,b12,b13,b21,b22,b23,b31,b33,b32};
			znalazlem = false;
			string symbolKomputera, symbolgracza;
			if (symbol)
			{
				symbolKomputera = "O";
				symbolgracza = "X";
			}
			else
			{
				symbolKomputera = "X";
				symbolgracza = "O";
			}
			

			//komputer sprawdza mozliwość wygrać
			//sprawdzamy poziomy 

			if ((b11.Text == symbolKomputera) && (b12.Text == symbolKomputera) && (b13.Text == ""))
				return(b13);
			else if ((b11.Text == symbolKomputera) && (b12.Text == "") && (b13.Text == symbolKomputera))
				return (b12);
			else if ((b11.Text == "") && (b12.Text == symbolKomputera) && (b13.Text == symbolKomputera))
				return (b11);

			else if ((b21.Text == symbolKomputera) && (b22.Text == symbolKomputera) && (b23.Text == ""))
				return (b23);
			else if ((b21.Text == symbolKomputera) && (b22.Text == "") && (b23.Text == symbolKomputera))
				return (b22);
			else if ((b21.Text == "") && (b22.Text == symbolKomputera) && (b23.Text == symbolKomputera))
				return (b21);

			else if ((b31.Text == symbolKomputera) && (b32.Text == symbolKomputera) && (b33.Text == ""))
				return (b33);
			else if ((b31.Text == symbolKomputera) && (b32.Text == "") && (b33.Text == symbolKomputera))
				return (b32);
			else if ((b31.Text == "") && (b32.Text == symbolKomputera) && (b33.Text == symbolKomputera))
				return (b31);

			//sprawdzamy pionowo
			else if ((b11.Text == symbolKomputera) && (b21.Text == symbolKomputera) && (b31.Text == ""))
				return (b31);
			else if ((b11.Text == symbolKomputera) && (b21.Text == "") && (b31.Text == symbolKomputera))
				return (b21);
			else if ((b11.Text == "") && (b21.Text == symbolKomputera) && (b31.Text == symbolKomputera))
				return (b11);

			else if ((b12.Text == symbolKomputera) && (b22.Text == symbolKomputera) && (b32.Text == ""))
				return (b32);
			else if ((b12.Text == symbolKomputera) && (b22.Text == "") && (b32.Text == symbolKomputera))
				return (b22);
			else if ((b12.Text == "") && (b22.Text == symbolKomputera) && (b32.Text == symbolKomputera))
				return (b12);

			else if ((b13.Text == symbolKomputera) && (b23.Text == symbolKomputera) && (b33.Text == ""))
				return (b33);
			else if ((b13.Text == symbolKomputera) && (b23.Text == "") && (b33.Text == symbolKomputera))
				return (b23);
			else if ((b13.Text == "") && (b23.Text == symbolKomputera) && (b33.Text == symbolKomputera))
				return (b13);


			//sprawdzamy przekątna;
			else if ((b11.Text == symbolKomputera) && (b22.Text == symbolKomputera) && (b33.Text == ""))
				return (b33);
			else if ((b11.Text == symbolKomputera) && (b22.Text == "") && (b33.Text == symbolKomputera))
				return (b22);
			else if ((b11.Text == "") && (b22.Text == symbolKomputera) && (b33.Text == symbolKomputera))
				return (b11);

			else if ((b31.Text == symbolKomputera) && (b22.Text == symbolKomputera) && (b13.Text == ""))
				return (b13);
			else if ((b31.Text == symbolKomputera) && (b22.Text == "") && (b13.Text == symbolKomputera))
				return (b22);
			else if ((b31.Text == "") && (b22.Text == symbolKomputera) && (b13.Text == symbolKomputera))
				return (b31);

			//Komputer sprawdza możliwość bloku
			//sprawdzamy poziomy 

			if ((b11.Text == symbolgracza) && (b12.Text == symbolgracza) && (b13.Text == ""))
				return (b13);
			else if ((b11.Text == symbolgracza) && (b12.Text == "") && (b13.Text == symbolgracza))
				return (b12);
			else if ((b11.Text == "") && (b12.Text == symbolgracza) && (b13.Text == symbolgracza))
				return (b11);

			else if ((b21.Text == symbolgracza) && (b22.Text == symbolgracza) && (b23.Text == ""))
				return (b23);
			else if ((b21.Text == symbolgracza) && (b22.Text == "") && (b23.Text == symbolgracza))
				return (b22);
			else if ((b21.Text == "") && (b22.Text == symbolgracza) && (b23.Text == symbolgracza))
				return (b21);

			else if ((b31.Text == symbolgracza) && (b32.Text == symbolgracza) && (b33.Text == ""))
				return (b33);
			else if ((b31.Text == symbolgracza) && (b32.Text == "") && (b33.Text == symbolgracza))
				return (b32);
			else if ((b31.Text == "") && (b32.Text == symbolgracza) && (b33.Text == symbolgracza))
				return (b31);

			//sprawdzamy pionowo
			else if ((b12.Text == symbolgracza) && (b21.Text == symbolgracza) && (b31.Text == ""))
				return (b31);
			else if ((b21.Text == symbolgracza) && (b21.Text == "") && (b31.Text == symbolgracza))
				return (b12);
			else if ((b12.Text == "") && (b21.Text == symbolgracza) && (b31.Text == symbolgracza))
				return (b12);

			else if ((b12.Text == symbolgracza) && (b22.Text == symbolgracza) && (b32.Text == ""))
				return (b32);
			else if ((b12.Text == symbolgracza) && (b22.Text == "") && (b32.Text == symbolgracza))
				return (b22);
			else if ((b12.Text == "") && (b22.Text == symbolgracza) && (b32.Text == symbolgracza))
				return (b12);

			else if ((b13.Text == symbolgracza) && (b23.Text == symbolgracza) && (b33.Text == ""))
				return (b33);
			else if ((b13.Text == symbolgracza) && (b23.Text == "") && (b33.Text == symbolgracza))
				return (b23);
			else if ((b13.Text == "") && (b23.Text == symbolgracza) && (b33.Text == symbolgracza))
				return (b13);


			//sprawdzamy przekątna;
			else if ((b11.Text == symbolgracza) && (b22.Text == symbolgracza) && (b33.Text == ""))
				return (b33);
			else if ((b11.Text == symbolgracza) && (b22.Text == "") && (b33.Text == symbolgracza))
				return (b22);
			else if ((b11.Text == "") && (b22.Text == symbolgracza) && (b33.Text == symbolgracza))
				return (b11);

			else if ((b31.Text == symbolgracza) && (b22.Text == symbolgracza) && (b13.Text == ""))
				return (b13);
			else if ((b31.Text == symbolgracza) && (b22.Text == "") && (b13.Text == symbolgracza))
				return (b22);
			else if ((b31.Text == "") && (b22.Text == symbolgracza) && (b13.Text == symbolgracza))
				return (b31);

			//sprawdza czy centrum jest wolny
			else if (b22.Text == "")
			{
				
				label_chat.Text = "Zająłem środek";
				return b22;
			}
			//sprawdza czy kąty są wolne
			else if (b11.Text == "")
				return b11;
			else if (b31.Text == "")
				return b31;
			else if (b13.Text == "")
				return b13;
			else if (b33.Text == "")
				return b33;

			//szukamy wolne mejsce
			else
			{
				foreach (Component c in Controls)
				{
					if (c.GetType() == typeof(Button))
					{
						Button b = (Button)c;
						if (b.Text == "")
							knopka = b;
					}
				}
				return knopka;
			}
					





		}

		private void grazaX_Click(object sender, EventArgs e)
		{
			foreach (Component c in Controls)
			{
				if (c.GetType() == typeof(Button))
				{
					Button b = (Button)c;
					b.BackColor = Color.FromKnownColor(KnownColor.Control);
					b.Enabled = true;
					b.Text = "";
				}
			}
					Reset.Text = "Reset";
					ilośćKroków = 0;
					symbol = true;
					grazaX.Text = "Gracz za X";
					grazaO.Text = "Gracz za O";

					grazaO.Enabled = false;
					grazaX.Enabled = false;
				
			
		}

		private void grazaO_Click(object sender, EventArgs e)
		{
			foreach (Component c in Controls)
			{

				if (c.GetType() == typeof(Button))
				{



					Button b = (Button)c;
					b.BackColor = Color.FromKnownColor(KnownColor.Control);
					b.Enabled = true;
					b.Text = "";
				}
			}
					Reset.Text = "Reset";
					ilośćKroków = 0;
					symbol = false;

					grazaO.Text = "Gracz za O";
					grazaX.Text = "Gracz za X";
					grazaO.Enabled = false;
					grazaX.Enabled = false;
				Komputerchodzi(szukaKomputer());
		}

		private bool SprawdżCzyKtośWygra(in string symbol)
		{
			//sprawdzamy poziomy 
			int count = 0;
			if ((b11.Text == symbol) && (b12.Text == symbol) && (b13.Text == ""))
				count++;
			 if ((b11.Text == symbol) && (b12.Text == "") && (b13.Text == symbol))
				count++;
			 if ((b11.Text == "") && (b12.Text == symbol) && (b13.Text == symbol))
				count++;

			 if ((b21.Text == symbol) && (b22.Text == symbol) && (b23.Text == ""))
				count++;
			 if ((b21.Text == symbol) && (b22.Text == "") && (b23.Text == symbol))
				count++;
			 if ((b21.Text == "") && (b22.Text == symbol) && (b23.Text == symbol))
				count++;

			 if ((b31.Text == symbol) && (b32.Text == symbol) && (b33.Text == ""))
				count++;
			 if ((b31.Text == symbol) && (b32.Text == "") && (b33.Text == symbol))
				count++;
			 if ((b31.Text == "") && (b32.Text == symbol) && (b33.Text == symbol))
				count++;

			//sprawdzamy pionowo
			 if ((b11.Text == symbol) && (b21.Text == symbol) && (b31.Text == ""))
				count++;
			 if ((b11.Text == symbol) && (b21.Text == "") && (b31.Text == symbol))
				count++;
			 if ((b11.Text == "") && (b21.Text == symbol) && (b31.Text == symbol))
				count++;
			 if ((b12.Text == symbol) && (b22.Text == symbol) && (b32.Text == ""))
				count++;
			 if ((b12.Text == symbol) && (b22.Text == "") && (b32.Text == symbol))
				count++;
			 if ((b12.Text == "") && (b22.Text == symbol) && (b32.Text == symbol))
				count++;
			 if ((b13.Text == symbol) && (b23.Text == symbol) && (b33.Text == ""))
				count++;
			 if ((b13.Text == symbol) && (b23.Text == "") && (b33.Text == symbol))
				count++;
			 if ((b13.Text == "") && (b23.Text == symbol) && (b33.Text == symbol))
				count++;

			//sprawdzamy przekątna;
			 if ((b11.Text == symbol) && (b22.Text == symbol) && (b33.Text == ""))
				count++;
			 if ((b11.Text == symbol) && (b22.Text == "") && (b33.Text == symbol))
				count++;
			 if ((b11.Text == "") && (b22.Text == symbol) && (b33.Text == symbol))
				count++;
			 if ((b31.Text == symbol) && (b22.Text == symbol) && (b13.Text == ""))
				count++;
			 if ((b31.Text == symbol) && (b22.Text == "") && (b13.Text == symbol))
				count++;
			 if ((b31.Text == "") && (b22.Text == symbol) && (b13.Text == symbol))
				count++;

			if (count > 1)
				return true;
			else return false;
		}

		
	}
}
