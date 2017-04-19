using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournementAndAnalysis
{
    enum ELIMSCENE { None, AskForAmount, Two, Four, Eight}
    public class TournementHolder
    {
        private static TournementHolder instance;
        public static TournementHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TournementHolder();
                }
                return instance;
            }
        }

        private Graphics dc;

        private Color backCol;
        private Color foreCol;

        private Random rnd;

        private ELIMSCENE scene;
        private Form1 frm;
        private List<Button> buttons;
        private TextBox amount;

        private TournementHolder()
        {
            buttons = new List<Button>();
        }



        public void Load(Form1 x, Graphics dc)
        {
            rnd = new Random();
            scene = ELIMSCENE.None;
            frm = x;
            this.dc = dc;
            foreach (object obj in frm.Controls)
            {
                if (obj is Button)
                {
                    if ((string)(obj as Button).Tag == "Elimbutton")
                    {
                        buttons.Add((obj as Button));
                        (obj as Button).Hide();
                    }
                }
                if (obj is TextBox)
                {
                    amount = (frm.Controls.Find("ElimAmount", true).FirstOrDefault() as TextBox);
                    amount.Hide();
                }
            }
            backCol = buttons[0].BackColor;
            foreCol = buttons[0].ForeColor;
        }

        public void AskForAmount()
        {
            scene = ELIMSCENE.AskForAmount;
            Hide();
        }

        public void SetupForEight()
        {
            foreach (Button btn in buttons) { btn.BackColor = backCol; btn.ForeColor = foreCol; }
            scene = ELIMSCENE.Eight;
            Hide();
        }

        public void TournementTick()
        {
            switch (scene)
            {
                case ELIMSCENE.AskForAmount:
                    {
                        var okButton = buttons.Find(x => x.Name == "OK");
                        var backButton = buttons.Find(x=>x.Name == "Back");
                        okButton.Location = new Point(frm.Width - frm.Width / 3 - okButton.Width / 2, frm.Height / 2 - okButton.Height / 2);
                        amount.Location = new Point(frm.Width / 3 - amount.Width / 2, frm.Height / 2 - amount.Height / 2);
                        backButton.Location = new Point(frm.Width / 2 - backButton.Width / 2, (frm.Height / 3) * 2);
                        if (!amount.Visible) { amount.Show(); }
                        if (!okButton.Visible) { okButton.Show(); }
                        if (!backButton.Visible) { backButton.Show(); }
                        break;
                    }
                case ELIMSCENE.Two:
                    {
                        break;
                    }
                case ELIMSCENE.Four:
                    {
                        break;
                    }
                case ELIMSCENE.Eight:
                    {
                        ElimEight();
                        break;
                    }
            }
        }

        public void NextRound()
        {
            switch (scene)
            {
                case ELIMSCENE.Eight:
                    {
                        if ((buttons.Find(x => x.Name == "Elimbutton1") as Button).BackColor == backCol)
                        {
                            ColourButtons(buttons.Find(x => x.Name == "Elimbutton1"), buttons.Find(x => x.Name == "Elimbutton2"), buttons.Find(x => x.Name == "ElimA1v2"));
                        } else if ((buttons.Find(x => x.Name == "Elimbutton3") as Button).BackColor == backCol)
                        {
                            ColourButtons(buttons.Find(x => x.Name == "Elimbutton3"), buttons.Find(x => x.Name == "Elimbutton4"), buttons.Find(x => x.Name == "ElimB3v4"));
                        } else if ((buttons.Find(x => x.Name == "Elimbutton5") as Button).BackColor == backCol)
                        {
                            ColourButtons(buttons.Find(x => x.Name == "Elimbutton5"), buttons.Find(x => x.Name == "Elimbutton6"), buttons.Find(x => x.Name == "ElimC5v6"));
                        } else if ((buttons.Find(x => x.Name == "Elimbutton7") as Button).BackColor == backCol)
                        {
                            ColourButtons(buttons.Find(x => x.Name == "Elimbutton7"), buttons.Find(x => x.Name == "Elimbutton8"), buttons.Find(x => x.Name == "ElimD7v8"));
                        } else if ((buttons.Find(x => x.Name == "ElimA1v2") as Button).BackColor == backCol)
                        {
                            ColourButtons(buttons.Find(x => x.Name == "ElimA1v2"), buttons.Find(x => x.Name == "ElimB3v4"), buttons.Find(x => x.Name == "ElimAvB"));
                        } else if ((buttons.Find(x => x.Name == "ElimC5v6") as Button).BackColor == backCol)
                        {
                            ColourButtons(buttons.Find(x => x.Name == "ElimC5v6"), buttons.Find(x => x.Name == "ElimD7v8"), buttons.Find(x => x.Name == "ElimCvD"));
                        } else if ((buttons.Find(x => x.Name == "ElimAvB") as Button).BackColor == backCol)
                        {
                            ColourButtons(buttons.Find(x => x.Name == "ElimAvB"), buttons.Find(x => x.Name == "ElimCvD"), buttons.Find(x => x.Name == "ElimFinalABvCD"));
                        }
                        break;
                    }
            }
        }

        public void GoBackToMenu()
        {
            scene = ELIMSCENE.None;
            foreach (Button btn in buttons) { btn.Hide(); }
            amount.Text = "Antal Deltagere";
            amount.Hide();
            frm.Scene1 = MENUSCENE.Menu;
        }

        private void ColourButtons(Button a, Button b, Button t)
        {
            if (rnd.Next(2) == 0)
            {
                a.BackColor = Color.Green;
                b.BackColor = Color.Red;
                t.Text = a.Text;
            } else
            {
                a.BackColor = Color.Red;
                b.BackColor = Color.Green;
                t.Text = b.Text;
            }
            if (t.Name == "ElimFinalABvCD")
            {
                t.BackColor = Color.Gold;
            }
        }

        private void Hide()
        {
            foreach (Button btn in buttons) { btn.Hide(); }
            amount.Hide();
        }

        //

        
        private void ElimEight()
        {
            foreach (Button btn in buttons)
            {
                switch (btn.Name)
                {
                    case "Elimbutton1":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 1 - btn.Width / 2, (frm.Height / 8) * 1 - btn.Height);
                            break;
                        }
                    case "Elimbutton2":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 1 - btn.Width / 2, (frm.Height / 8) * 3 - btn.Height);
                            break;
                        }
                    case "Elimbutton3":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 1 - btn.Width / 2, (frm.Height / 8) * 5 - btn.Height);
                            break;
                        }
                    case "Elimbutton4":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 1 - btn.Width / 2, (frm.Height / 8) * 7 - btn.Height);
                            break;
                        }
                    case "Elimbutton5":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 7 - btn.Width / 2, (frm.Height / 8) * 1 - btn.Height);
                            break;
                        }
                    case "Elimbutton6":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 7 - btn.Width / 2, (frm.Height / 8) * 3 - btn.Height);
                            break;
                        }
                    case "Elimbutton7":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 7 - btn.Width / 2, (frm.Height / 8) * 5 - btn.Height);
                            break;
                        }
                    case "Elimbutton8":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 7 - btn.Width / 2, (frm.Height / 8) * 7 - btn.Height);
                            break;
                        }
                    case "ElimA1v2":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 2 - btn.Width / 2, (frm.Height / 8) * 2 - btn.Height);
                            break;
                        }
                    case "ElimB3v4":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 2 - btn.Width / 2, (frm.Height / 8) * 6 - btn.Height);
                            break;
                        }
                    case "ElimC5v6":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 6 - btn.Width / 2, (frm.Height / 8) * 2 - btn.Height);
                            break;
                        }
                    case "ElimD7v8":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 6 - btn.Width / 2, (frm.Height / 8) * 6 - btn.Height);
                            break;
                        }
                    case "ElimAvB":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 3 - btn.Width / 2, (frm.Height / 8) * 4 - btn.Height);
                            break;
                        }
                    case "ElimCvD":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 5 - btn.Width / 2, (frm.Height / 8) * 4 - btn.Height);
                            break;
                        }
                    case "ElimFinalABvCD":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 4 - btn.Width / 2, (frm.Height / 8) * 4 - btn.Height);
                            break;
                        }
                    case "ElimWinner":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 4 - btn.Width / 2, (frm.Height / 8) * 7 - btn.Height);
                            break;
                        }
                    case "Back":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 3 - btn.Width / 2, (frm.Height / 8) * 7 - btn.Height);
                            break;
                        }
                }
            }

            DrawLines(buttons.Find(x => x.Name == "Elimbutton1"), buttons.Find(x => x.Name == "Elimbutton2"), buttons.Find(x => x.Name == "ElimA1v2"));
            DrawLines(buttons.Find(x => x.Name == "Elimbutton3"), buttons.Find(x => x.Name == "Elimbutton4"), buttons.Find(x => x.Name == "ElimB3v4"));
            DrawLines(buttons.Find(x => x.Name == "ElimA1v2"), buttons.Find(x => x.Name == "ElimB3v4"), buttons.Find(x => x.Name == "ElimAvB"));
            DrawLines(buttons.Find(x => x.Name == "Elimbutton5"), buttons.Find(x => x.Name == "Elimbutton6"), buttons.Find(x => x.Name == "ElimC5v6"));
            DrawLines(buttons.Find(x => x.Name == "Elimbutton7"), buttons.Find(x => x.Name == "Elimbutton8"), buttons.Find(x => x.Name == "ElimD7v8"));
            DrawLines(buttons.Find(x => x.Name == "ElimC5v6"), buttons.Find(x => x.Name == "ElimD7v8"), buttons.Find(x => x.Name == "ElimCvD"));
        }

        private Pen blackP = new Pen(Color.Black, 3);
        private void DrawLines(Button a, Button b, Button t)
        {
            if (t.Location.X > a.Location.X && t.Location.X > b.Location.X)
            {
                dc.DrawLine(blackP, new Point(a.Location.X + a.Width, a.Location.Y + (a.Height / 2)), new Point(a.Location.X + a.Width + (t.Location.X - (a.Location.X + a.Width)) / 2, a.Location.Y + (a.Height / 2)));
                dc.DrawLine(blackP, new Point(b.Location.X + b.Width, b.Location.Y + (b.Height / 2)), new Point(b.Location.X + b.Width + (t.Location.X - (b.Location.X + b.Width)) / 2, b.Location.Y + (b.Height / 2)));
                dc.DrawLine(blackP, new Point(a.Location.X + a.Width + (t.Location.X - (a.Location.X + a.Width)) / 2, a.Location.Y + (a.Height / 2)), new Point(a.Location.X + a.Width + (t.Location.X - (a.Location.X + a.Width)) / 2, a.Location.Y + (a.Height / 2) + ((b.Location.Y - a.Location.Y) / 2)));
                dc.DrawLine(blackP, new Point(b.Location.X + b.Width + (t.Location.X - (b.Location.X + b.Width)) / 2, b.Location.Y + (b.Height / 2)), new Point(b.Location.X + b.Width + (t.Location.X - (b.Location.X + b.Width)) / 2, b.Location.Y + (b.Height / 2) - ((b.Location.Y - a.Location.Y) / 2)));
                dc.DrawLine(blackP, new Point(a.Location.X + a.Width + (t.Location.X - (a.Location.X + a.Width)) / 2, a.Location.Y + (a.Height / 2) + ((b.Location.Y - a.Location.Y) / 2)), new Point(t.Location.X, t.Location.Y + (t.Height / 2)));
            } else if (t.Location.X < a.Location.X && t.Location.X < b.Location.X)
            {
                dc.DrawLine(blackP, new Point(a.Location.X, a.Location.Y + (a.Height / 2)), new Point(a.Location.X - ((a.Location.X - (t.Location.X + t.Width)) / 2), a.Location.Y + (a.Height / 2)));
                dc.DrawLine(blackP, new Point(b.Location.X, b.Location.Y + (b.Height / 2)), new Point(b.Location.X - ((b.Location.X - (t.Location.X + t.Width)) / 2), b.Location.Y + (b.Height / 2)));
                dc.DrawLine(blackP, new Point(a.Location.X - ((a.Location.X - (t.Location.X + t.Width)) / 2), a.Location.Y + (a.Height / 2)), new Point(a.Location.X - ((a.Location.X - (t.Location.X + t.Width)) / 2), t.Location.Y + (t.Height / 2)));
                dc.DrawLine(blackP, new Point(b.Location.X - ((b.Location.X - (t.Location.X + t.Width)) / 2), b.Location.Y + (b.Height / 2)), new Point(b.Location.X - ((b.Location.X - (t.Location.X + t.Width)) / 2), t.Location.Y + (t.Height / 2)));
                dc.DrawLine(blackP, new Point(a.Location.X - ((a.Location.X - (t.Location.X + t.Width)) / 2), t.Location.Y + (t.Height / 2)), new Point(t.Location.X + t.Width, t.Location.Y + (t.Height / 2)));
            }
        }
    }
}
