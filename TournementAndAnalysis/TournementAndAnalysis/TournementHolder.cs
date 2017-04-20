using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournementAndAnalysis
{
    enum ELIMSCENE { None, AskForAmount, Four, Eight, Sixteen, ThirtyTwo, }
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
        private bool changingName;
        private bool started;

        private TournementHolder()
        {
            buttons = new List<Button>();
        }



        public void Load(Form1 x, Graphics dc)
        {
            rnd = new Random();
            scene = ELIMSCENE.None;
            frm = x;
            changingName = false;
            started = false;
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

        public void SetupForFour()
        {
            foreach (Button btn in buttons)
            {
                btn.BackColor = backCol; btn.ForeColor = foreCol;
                if (!btn.Name.Contains("button") && !btn.Name.Contains("Amount") && !btn.Name.Contains("Winner") && !btn.Name.Contains("GroupsOf") && !btn.Name.Contains("Hold") && btn.Name.Contains("Elim"))
                {
                    btn.Text = "";
                }
            }
            scene = ELIMSCENE.Four;
            Hide();
        }

        public void SetupForEight()
        {
            foreach (Button btn in buttons)
            {
                btn.BackColor = backCol; btn.ForeColor = foreCol;
                if (!btn.Name.Contains("button") && !btn.Name.Contains("Amount") && !btn.Name.Contains("Winner") && !btn.Name.Contains("GroupsOf") && !btn.Name.Contains("Hold") && btn.Name.Contains("Elim"))
                {
                    btn.Text = "";
                }
            }
            scene = ELIMSCENE.Eight;
            Hide();
        }

        public void SetupForSixTeen()
        {
            foreach (Button btn in buttons)
            {
                btn.BackColor = backCol; btn.ForeColor = foreCol;
                if (!btn.Name.Contains("button") && !btn.Name.Contains("Amount") && !btn.Name.Contains("Winner") && !btn.Name.Contains("GroupsOf") && !btn.Name.Contains("Hold") && btn.Name.Contains("Elim"))
                {
                    btn.Text = "";
                }
            }
            scene = ELIMSCENE.Sixteen;
            Hide();
        }


        public void SetupForThirtyTwo()
        {
            foreach (Button btn in buttons)
            {
                btn.BackColor = backCol; btn.ForeColor = foreCol;
                if (!btn.Name.Contains("button") && !btn.Name.Contains("Amount") && !btn.Name.Contains("Winner") && !btn.Name.Contains("GroupsOf") && !btn.Name.Contains("Hold") && btn.Name.Contains("Elim"))
                {
                    btn.Text = "";
                }
            }
            scene = ELIMSCENE.ThirtyTwo;
            Hide();
        }

        public void TournementTick()
        {
            List<Button> btns = new List<Button>();
            foreach (object btn in frm.Controls) { if (btn is Button) { if ((btn as Button).Name.Contains("ElimGroupsOf")) { btns.Add(btn as Button); } } }
            if (scene != ELIMSCENE.AskForAmount)
            {
                foreach (Button btn in btns) { if (btn.Visible) { btn.Hide(); } }
            } else { foreach (Button btn in btns) { if (!btn.Visible) { btn.Show(); } } }
            switch (scene)
            {
                case ELIMSCENE.AskForAmount:
                    {
                        /*      var okButton = buttons.Find(x => x.Name == "OK");
                              var backButton = buttons.Find(x=>x.Name == "Back");
                              okButton.Location = new Point(frm.Width - frm.Width / 3 - okButton.Width / 2, frm.Height / 2 - okButton.Height / 2);
                              amount.Location = new Point(frm.Width / 3 - amount.Width / 2, frm.Height / 2 - amount.Height / 2);
                              backButton.Location = new Point(frm.Width / 2 - backButton.Width / 2, (frm.Height / 3) * 2);
                              if (!amount.Visible) { amount.Show(); }
                              if (!okButton.Visible) { okButton.Show(); }
                              if (!backButton.Visible) { backButton.Show(); }
                            */
                        break;
                    }
                case ELIMSCENE.Four:
                    {
                        ElimFour();
                        break;
                    }
                case ELIMSCENE.Eight:
                    {
                        ElimEight();
                        break;

                    }
                case ELIMSCENE.Sixteen:
                    {
                        ElimSixTeen();
                        break;
                    }
                case ELIMSCENE.ThirtyTwo:
                    {
                        ElimThirtyTwo();
                        break;
                    }
            }
        }

        public void NextRound()
        {
            if (started)
            {
                switch (scene)
                {

                    case ELIMSCENE.Four:
                        {
                            if ((buttons.Find(x => x.Name == "Elimbutton1") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Elimbutton1"), buttons.Find(x => x.Name == "Elimbutton2"), buttons.Find(x => x.Name == "ElimA1v2"));
                            } else if ((buttons.Find(x => x.Name == "Elimbutton3") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Elimbutton3"), buttons.Find(x => x.Name == "Elimbutton4"), buttons.Find(x => x.Name == "ElimB3v4"));
                            } else if ((buttons.Find(x => x.Name == "ElimA1v2") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimA1v2"), buttons.Find(x => x.Name == "ElimB3v4"), buttons.Find(x => x.Name == "ElimAvB"));
                            }


                            break;
                        }

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

                    case ELIMSCENE.Sixteen:
                        {
                            if ((buttons.Find(x => x.Name == "Elimbutton1") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Elimbutton1"), buttons.Find(x => x.Name == "Elimbutton2"), buttons.Find(x => x.Name == "ElimA1v2"));
                            }
                            else if ((buttons.Find(x => x.Name == "Elimbutton3") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Elimbutton3"), buttons.Find(x => x.Name == "Elimbutton4"), buttons.Find(x => x.Name == "ElimB3v4"));
                            }
                            else if ((buttons.Find(x => x.Name == "Elimbutton5") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Elimbutton5"), buttons.Find(x => x.Name == "Elimbutton6"), buttons.Find(x => x.Name == "ElimC5v6"));
                            }
                            else if ((buttons.Find(x => x.Name == "Elimbutton7") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Elimbutton7"), buttons.Find(x => x.Name == "Elimbutton8"), buttons.Find(x => x.Name == "ElimD7v8"));
                            }
                           
                            else if ((buttons.Find(x => x.Name == "Hold17") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold17"), buttons.Find(x => x.Name == "Hold18"), buttons.Find(x => x.Name == "ElimI17v18"));
                            }
                            else if ((buttons.Find(x => x.Name == "Hold19") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold19"), buttons.Find(x => x.Name == "Hold20"), buttons.Find(x => x.Name == "ElimJ19v20"));
                            }
                            else if ((buttons.Find(x => x.Name == "Hold21") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold21"), buttons.Find(x => x.Name == "Hold22"), buttons.Find(x => x.Name == "ElimK21v22"));
                            }
                            else if ((buttons.Find(x => x.Name == "Hold23") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold23"), buttons.Find(x => x.Name == "Hold24"), buttons.Find(x => x.Name == "ElimL23v24"));
                            }
                           
                            else if ((buttons.Find(x => x.Name == "ElimA1v2") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimA1v2"), buttons.Find(x => x.Name == "ElimB3v4"), buttons.Find(x => x.Name == "ElimAvB"));
                            }
                            else if ((buttons.Find(x => x.Name == "ElimC5v6") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimC5v6"), buttons.Find(x => x.Name == "ElimD7v8"), buttons.Find(x => x.Name == "ElimCvD"));
                            }
                           
                            else if ((buttons.Find(x => x.Name == "ElimI17v18") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimI17v18"), buttons.Find(x => x.Name == "ElimJ19v20"), buttons.Find(x => x.Name == "ElimIvJ"));
                            }
                            else if ((buttons.Find(x => x.Name == "ElimK21v22") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimK21v22"), buttons.Find(x => x.Name == "ElimL23v24"), buttons.Find(x => x.Name == "ElimKvL"));
                            }
                            else if ((buttons.Find(x => x.Name == "ElimAvB") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimAvB"), buttons.Find(x => x.Name == "ElimCvD"), buttons.Find(x => x.Name == "ElimFinalABvCD"));
                            }
                            
                            else if ((buttons.Find(x => x.Name == "ElimIvJ") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimIvJ"), buttons.Find(x => x.Name == "ElimKvL"), buttons.Find(x => x.Name == "ElimIvL"));
                            }
                          
                            else if ((buttons.Find(x => x.Name == "ElimIvL") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimIvL"), buttons.Find(x => x.Name == "ElimFinalABvCD"), buttons.Find(x => x.Name == "ElimAvH"));
                            }
                           
                            break;
                        }

                    case ELIMSCENE.ThirtyTwo:
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
                            } else if ((buttons.Find(x => x.Name == "Hold9") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold9"), buttons.Find(x => x.Name == "Hold10"), buttons.Find(x => x.Name == "ElimE9v10"));
                            } else if ((buttons.Find(x => x.Name == "Hold11") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold11"), buttons.Find(x => x.Name == "Hold12"), buttons.Find(x => x.Name == "ElimF11v12"));
                            } else if ((buttons.Find(x => x.Name == "Hold13") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold13"), buttons.Find(x => x.Name == "Hold14"), buttons.Find(x => x.Name == "ElimG13v14"));
                            } else if ((buttons.Find(x => x.Name == "Hold15") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold15"), buttons.Find(x => x.Name == "Hold16"), buttons.Find(x => x.Name == "ElimH15v16"));
                            } else if ((buttons.Find(x => x.Name == "Hold17") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold17"), buttons.Find(x => x.Name == "Hold18"), buttons.Find(x => x.Name == "ElimI17v18"));
                            } else if ((buttons.Find(x => x.Name == "Hold19") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold19"), buttons.Find(x => x.Name == "Hold20"), buttons.Find(x => x.Name == "ElimJ19v20"));
                            } else if ((buttons.Find(x => x.Name == "Hold21") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold21"), buttons.Find(x => x.Name == "Hold22"), buttons.Find(x => x.Name == "ElimK21v22"));
                            } else if ((buttons.Find(x => x.Name == "Hold23") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold23"), buttons.Find(x => x.Name == "Hold24"), buttons.Find(x => x.Name == "ElimL23v24"));
                            } else if ((buttons.Find(x => x.Name == "Hold25") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold25"), buttons.Find(x => x.Name == "Hold26"), buttons.Find(x => x.Name == "ElimM25v26"));
                            } else if ((buttons.Find(x => x.Name == "Hold27") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold27"), buttons.Find(x => x.Name == "Hold28"), buttons.Find(x => x.Name == "ElimN27v28"));
                            } else if ((buttons.Find(x => x.Name == "Hold29") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold29"), buttons.Find(x => x.Name == "Hold30"), buttons.Find(x => x.Name == "ElimO29v30"));
                            } else if ((buttons.Find(x => x.Name == "Hold31") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "Hold31"), buttons.Find(x => x.Name == "Hold32"), buttons.Find(x => x.Name == "ElimP31v32"));
                            } else if ((buttons.Find(x => x.Name == "ElimA1v2") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimA1v2"), buttons.Find(x => x.Name == "ElimB3v4"), buttons.Find(x => x.Name == "ElimAvB"));
                            } else if ((buttons.Find(x => x.Name == "ElimC5v6") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimC5v6"), buttons.Find(x => x.Name == "ElimD7v8"), buttons.Find(x => x.Name == "ElimCvD"));
                            } else if ((buttons.Find(x => x.Name == "ElimE9v10") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimE9v10"), buttons.Find(x => x.Name == "ElimF11v12"), buttons.Find(x => x.Name == "ElimEvF"));
                            } else if ((buttons.Find(x => x.Name == "ElimG13v14") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimG13v14"), buttons.Find(x => x.Name == "ElimH15v16"), buttons.Find(x => x.Name == "ElimGvH"));
                            } else if ((buttons.Find(x => x.Name == "ElimI17v18") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimI17v18"), buttons.Find(x => x.Name == "ElimJ19v20"), buttons.Find(x => x.Name == "ElimIvJ"));
                            } else if ((buttons.Find(x => x.Name == "ElimK21v22") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimK21v22"), buttons.Find(x => x.Name == "ElimL23v24"), buttons.Find(x => x.Name == "ElimKvL"));
                            } else if ((buttons.Find(x => x.Name == "ElimM25v26") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimM25v26"), buttons.Find(x => x.Name == "ElimN27v28"), buttons.Find(x => x.Name == "ElimMvN"));
                            } else if ((buttons.Find(x => x.Name == "ElimO29v30") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimO29v30"), buttons.Find(x => x.Name == "ElimP31v32"), buttons.Find(x => x.Name == "ElimOvP"));
                            } else if ((buttons.Find(x => x.Name == "ElimAvB") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimAvB"), buttons.Find(x => x.Name == "ElimCvD"), buttons.Find(x => x.Name == "ElimFinalABvCD"));
                            } else if ((buttons.Find(x => x.Name == "ElimEvF") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimEvF"), buttons.Find(x => x.Name == "ElimGvH"), buttons.Find(x => x.Name == "ElimEvH"));
                            } else if ((buttons.Find(x => x.Name == "ElimIvJ") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimIvJ"), buttons.Find(x => x.Name == "ElimKvL"), buttons.Find(x => x.Name == "ElimIvL"));
                            } else if ((buttons.Find(x => x.Name == "ElimMvN") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimMvN"), buttons.Find(x => x.Name == "ElimOvP"), buttons.Find(x => x.Name == "ElimMvP"));
                            } else if ((buttons.Find(x => x.Name == "ElimFinalABvCD") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimFinalABvCD"), buttons.Find(x => x.Name == "ElimEvH"), buttons.Find(x => x.Name == "ElimAvH"));
                            } else if ((buttons.Find(x => x.Name == "ElimIvL") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimIvL"), buttons.Find(x => x.Name == "ElimMvP"), buttons.Find(x => x.Name == "ElimIvP"));
                            } else if ((buttons.Find(x => x.Name == "ElimAvH") as Button).BackColor == backCol)
                            {
                                ColourButtons(buttons.Find(x => x.Name == "ElimAvH"), buttons.Find(x => x.Name == "ElimIvP"), buttons.Find(x => x.Name == "ElimAvP"));
                            }
                            break;
                        }

                }
            } else if (changingName)
            {
                Button kort = buttons.Find(x => x.BackColor == Color.Blue);
                kort.Text = amount.Text;
                kort.BackColor = backCol;
                buttons.Find(X => X.Name == "ElimWinner").Text = "Start";
                changingName = false;
            } else
            {
                buttons.Find(X => X.Name == "ElimWinner").Text = "Kør Runde";
                started = true;
            }
        }

        public void GoBackToMenu()
        {
            started = false;
            scene = ELIMSCENE.None;
            foreach (Button btn in buttons) { btn.Hide(); }
            amount.Text = "Antal Deltagere";
            amount.Hide();
            frm.Scene1 = MENUSCENE.Menu;
        }

        public void ChangeElimButtonText(object x)
        {
            if (!started)
            {
                Button temp = null;
                foreach (Button btn in buttons)
                {
                    if (btn.BackColor == Color.Blue)
                    {
                        temp = btn;
                        break;
                    }
                }
                if (temp == null)
                {
                    (x as Button).BackColor = Color.Blue;
                    changingName = true;
                    buttons.Find(y => y.Name == "ElimWinner").Text = "Skift Deltager";
                    amount.Text = "Ny deltagernavn";
                } else if (temp == (x as Button))
                {
                    (x as Button).BackColor = backCol;
                    changingName = false;
                    buttons.Find(y => y.Name == "ElimWinner").Text = "Start";
                    amount.Text = "";
                } else
                {
                    (x as Button).BackColor = Color.Blue;
                    temp.BackColor = backCol;
                    changingName = true;
                    buttons.Find(y => y.Name == "ElimWinner").Text = "Skift Deltager";
                    amount.Text = "Ny deltagernavn";
                }
            }
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
            if (t.Name == "ElimFinalABvCD" && scene == ELIMSCENE.Eight)
            {
                t.BackColor = Color.Gold;
            }
            if (t.Name == "ElimAvB" && (scene == ELIMSCENE.Four))
            {
                t.BackColor = Color.Gold;
            }
            if (t.Name == "ElimAvH" && (scene == ELIMSCENE.Sixteen))
            {
                t.BackColor = Color.Gold;
            }
            if (t.Name == "ElimAvP" && (scene == ELIMSCENE.ThirtyTwo))
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
        private void ElimFour()
        {

            if (changingName)
            {
                amount.Location = new Point((frm.Width / 8) * 4 - amount.Width / 2, (frm.Height / 8) * 1 - amount.Height);
                if (!amount.Visible) { amount.Show(); }
            } else
            {
                if (amount.Visible) { amount.Hide(); }
            }
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

                    case "ElimAvB":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 8) * 3 - btn.Width / 2, (frm.Height / 8) * 4 - btn.Height);
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
        }

        private void ElimEight()
        {
            if (changingName)
            {
                amount.Location = new Point((frm.Width / 8) * 4 - amount.Width / 2, (frm.Height / 8) * 1 - amount.Height);
                if (!amount.Visible) { amount.Show(); }
            } else
            {
                if (amount.Visible) { amount.Hide(); }
            }
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

        private void ElimSixTeen()
        {
            if (changingName)
            {
                amount.Location = new Point((frm.Width / 10) * 5 - amount.Width / 2, (frm.Height / 10) * 1 - amount.Height);
                if (!amount.Visible) { amount.Show(); }
            }
            else
            {
                if (amount.Visible) { amount.Hide(); }
            }
            foreach (Button btn in buttons)
            {
                switch (btn.Name)
                {
                    case "Elimbutton1":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 1 - btn.Height);
                            break;
                        }
                    case "Elimbutton2":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 3 - btn.Height);
                            break;
                        }
                    case "Elimbutton3":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 5 - btn.Height);
                            break;
                        }
                    case "Elimbutton4":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 7 - btn.Height);
                            break;
                        }
                    case "Elimbutton5":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 9 - btn.Height);
                            break;
                        }
                    case "Elimbutton6":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 11 - btn.Height);
                            break;
                        }
                    case "Elimbutton7":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 13 - btn.Height);
                            break;
                        }
                    case "Elimbutton8":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 15 - btn.Height);
                            break;
                        }
                    
                    case "Hold17":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 1 - btn.Height);
                            break;
                        }
                    case "Hold18":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 3 - btn.Height);
                            break;
                        }
                    case "Hold19":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 5 - btn.Height);
                            break;
                        }
                    case "Hold20":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 7 - btn.Height);
                            break;
                        }
                    case "Hold21":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 9 - btn.Height);
                            break;
                        }
                    case "Hold22":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 11 - btn.Height);
                            break;
                        }
                    case "Hold23":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 13 - btn.Height);
                            break;
                        }
                    case "Hold24":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 15 - btn.Height);
                            break;
                        }
                   
                    case "ElimA1v2":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 2 - btn.Height);
                            break;
                        }
                    case "ElimB3v4":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 6 - btn.Height);
                            break;
                        }
                    case "ElimC5v6":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 10 - btn.Height);
                            break;
                        }
                    case "ElimD7v8":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 14 - btn.Height);
                            break;
                        }
                   
                    case "ElimI17v18":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 2 - btn.Height);
                            break;
                        }
                    case "ElimJ19v20":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 6 - btn.Height);
                            break;
                        }
                    case "ElimK21v22":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 10 - btn.Height);
                            break;
                        }
                    case "ElimL23v24":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 14 - btn.Height);
                            break;
                        }
                
                    case "ElimAvB":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 3 - btn.Width / 2, (frm.Height / 32) * 4 - btn.Height);
                            break;
                        }
                    case "ElimCvD":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 3 - btn.Width / 2, (frm.Height / 32) * 12 - btn.Height);
                            break;
                        }
                   
                    case "ElimIvJ":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 10 - btn.Width / 2, (frm.Height / 32) * 4 - btn.Height);
                            break;
                        }
                    case "ElimKvL":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 10 - btn.Width / 2, (frm.Height / 32) * 12 - btn.Height);
                            break;
                        }
                   
                    case "ElimFinalABvCD":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 4 - btn.Width / 2, (frm.Height / 32) * 8 - btn.Height);
                            break;
                        }
                
                    case "ElimIvL":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 8 - btn.Width / 2, (frm.Height / 32) * 8 - btn.Height);
                            break;
                        }
               
                    case "ElimAvH":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 5 - btn.Width / 2, (frm.Height / 32) * 16 - btn.Height);
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
        }
        private void ElimThirtyTwo()
        {
            if (changingName)
            {
                amount.Location = new Point((frm.Width / 10) * 5 - amount.Width / 2, (frm.Height / 10) * 1 - amount.Height);
                if (!amount.Visible) { amount.Show(); }
            } else
            {
                if (amount.Visible) { amount.Hide(); }
            }
            foreach (Button btn in buttons)
            {
                switch (btn.Name)
                {
                    case "Elimbutton1":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 1 - btn.Height);
                            break;
                        }
                    case "Elimbutton2":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 3 - btn.Height);
                            break;
                        }
                    case "Elimbutton3":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 5 - btn.Height);
                            break;
                        }
                    case "Elimbutton4":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 7 - btn.Height);
                            break;
                        }
                    case "Elimbutton5":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 9 - btn.Height);
                            break;
                        }
                    case "Elimbutton6":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 11 - btn.Height);
                            break;
                        }
                    case "Elimbutton7":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 13 - btn.Height);
                            break;
                        }
                    case "Elimbutton8":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 15 - btn.Height);
                            break;
                        }
                    case "Hold9":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 17 - btn.Height);
                            break;
                        }
                    case "Hold10":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 19 - btn.Height);
                            break;
                        }
                    case "Hold11":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 21 - btn.Height);
                            break;
                        }
                    case "Hold12":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 23 - btn.Height);
                            break;
                        }
                    case "Hold13":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 25 - btn.Height);
                            break;
                        }
                    case "Hold14":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 27 - btn.Height);
                            break;
                        }
                    case "Hold15":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 29 - btn.Height);
                            break;
                        }
                    case "Hold16":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 1 - btn.Width / 2, (frm.Height / 32) * 31 - btn.Height);
                            break;
                        }
                    case "Hold17":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 1 - btn.Height);
                            break;
                        }
                    case "Hold18":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 3 - btn.Height);
                            break;
                        }
                    case "Hold19":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 5 - btn.Height);
                            break;
                        }
                    case "Hold20":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 7 - btn.Height);
                            break;
                        }
                    case "Hold21":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 9 - btn.Height);
                            break;
                        }
                    case "Hold22":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 11 - btn.Height);
                            break;
                        }
                    case "Hold23":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 13 - btn.Height);
                            break;
                        }
                    case "Hold24":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 15 - btn.Height);
                            break;
                        }
                    case "Hold25":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 17 - btn.Height);
                            break;
                        }
                    case "Hold26":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 19 - btn.Height);
                            break;
                        }
                    case "Hold27":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 21 - btn.Height);
                            break;
                        }
                    case "Hold28":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 23 - btn.Height);
                            break;
                        }
                    case "Hold29":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 25 - btn.Height);
                            break;
                        }
                    case "Hold30":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 27 - btn.Height);
                            break;
                        }
                    case "Hold31":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 29 - btn.Height);
                            break;
                        }
                    case "Hold32":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 12 - btn.Width / 2, (frm.Height / 32) * 31 - btn.Height);
                            break;
                        }
                    case "ElimA1v2":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 2 - btn.Height);
                            break;
                        }
                    case "ElimB3v4":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 6 - btn.Height);
                            break;
                        }
                    case "ElimC5v6":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 10 - btn.Height);
                            break;
                        }
                    case "ElimD7v8":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 14 - btn.Height);
                            break;
                        }
                    case "ElimE9v10":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 18 - btn.Height);
                            break;
                        }
                    case "ElimF11v12":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 22 - btn.Height);
                            break;
                        }
                    case "ElimG13v14":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 26 - btn.Height);
                            break;
                        }
                    case "ElimH15v16":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 2 - btn.Width / 2, (frm.Height / 32) * 30 - btn.Height);
                            break;
                        }
                    case "ElimI17v18":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 2 - btn.Height);
                            break;
                        }
                    case "ElimJ19v20":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 6 - btn.Height);
                            break;
                        }
                    case "ElimK21v22":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 10 - btn.Height);
                            break;
                        }
                    case "ElimL23v24":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 14 - btn.Height);
                            break;
                        }
                    case "ElimM25v26":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 18 - btn.Height);
                            break;
                        }
                    case "ElimN27v28":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 22 - btn.Height);
                            break;
                        }
                    case "ElimO29v30":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 26 - btn.Height);
                            break;
                        }
                    case "ElimP31v32":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 11 - btn.Width / 2, (frm.Height / 32) * 30 - btn.Height);
                            break;
                        }
                    case "ElimAvB":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 3 - btn.Width / 2, (frm.Height / 32) * 4 - btn.Height);
                            break;
                        }
                    case "ElimCvD":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 3 - btn.Width / 2, (frm.Height / 32) * 12 - btn.Height);
                            break;
                        }
                    case "ElimEvF":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 3 - btn.Width / 2, (frm.Height / 32) * 20 - btn.Height);
                            break;
                        }
                    case "ElimGvH":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 3 - btn.Width / 2, (frm.Height / 32) * 28 - btn.Height);
                            break;
                        }
                    case "ElimIvJ":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 10 - btn.Width / 2, (frm.Height / 32) * 4 - btn.Height);
                            break;
                        }
                    case "ElimKvL":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 10 - btn.Width / 2, (frm.Height / 32) * 12 - btn.Height);
                            break;
                        }
                    case "ElimMvN":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 10 - btn.Width / 2, (frm.Height / 32) * 20 - btn.Height);
                            break;
                        }
                    case "ElimOvP":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 10 - btn.Width / 2, (frm.Height / 32) * 28 - btn.Height);
                            break;
                        }
                    case "ElimFinalABvCD":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 4 - btn.Width / 2, (frm.Height / 32) * 8 - btn.Height);
                            break;
                        }
                    case "ElimEvH":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 4 - btn.Width / 2, (frm.Height / 32) * 24 - btn.Height);
                            break;
                        }
                    case "ElimIvL":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 8 - btn.Width / 2, (frm.Height / 32) * 8 - btn.Height);
                            break;
                        }
                    case "ElimMvP":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 8 - btn.Width / 2, (frm.Height / 32) * 24 - btn.Height);
                            break;
                        }
                    case "ElimAvH":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 5 - btn.Width / 2, (frm.Height / 32) * 16 - btn.Height);
                            break;
                        }
                    case "ElimIvP":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 7 - btn.Width / 2, (frm.Height / 32) * 16 - btn.Height);
                            break;
                        }
                    case "ElimAvP":
                        {
                            if (!btn.Visible) { btn.Show(); }
                            btn.Location = new Point((frm.Width / 13) * 6 - btn.Width / 2, (frm.Height / 32) * 16 - btn.Height);
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
