namespace MemoryWin
{
    public partial class Form1 : Form
    {
        int[] tag = new int[2];
        int mov, clicks, found, tagIndex;
        Image[] farm = new Image[15];
        List<string> listPosition = new List<string>();
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            foreach (PictureBox img in Controls.OfType<PictureBox>())
            {
                tagIndex = int.Parse(string.Format("{0}", img.Tag));
                farm[tagIndex] = img.Image;
                img.Image = Properties.Resources.corn1;
                //img.Refresh();
                img.Enabled = true;
            }
            Positions();
        }
        private void Positions()
        {
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                Random rdn = new Random();

                int[] xP = { 12, 161, 310, 455, 599, 748 };
                int[] yP = { 12, 184, 355, 526, 699 };

            Repeat:
                var X = xP[rdn.Next(0, xP.Length)];
                var Y = yP[rdn.Next(0, yP.Length)];

                string verification = X.ToString() + Y.ToString();

                if (listPosition.Contains(verification))
                {
                    goto Repeat;
                }
                else
                {
                    item.Location = new Point(X, Y);
                    listPosition.Add(verification);
                }
            }
        }
        private void ImageClick_Clik(Object sender, EventArgs e)
        {
            bool gotIt = false;
            PictureBox pic = (PictureBox)sender;
            clicks++;
            tagIndex = int.Parse(String.Format("{0}", pic.Tag));
            pic.Image = farm[tagIndex];
            pic.Refresh();

            if (clicks == 1)
            {
                tag[0] = int.Parse(String.Format("{0}", pic.Tag));
            }
            else if (clicks == 2)
            {
                mov++;
                lblMovimento.Text = "Movements: " + mov.ToString();
                tag[1] = int.Parse(String.Format("{0}", pic.Tag));
                gotIt = PairValidation();
                ShowUp(gotIt);
            }

        }
        private bool PairValidation()
        {
            clicks = 0;
            if (tag[0] == tag[1]) { return true; }
            else { return false; }
        }

        private void ShowUp(bool check)
        {
            Thread.Sleep(500);
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                if (int.Parse(String.Format("{0}", item.Tag)) == tag[0] ||
                    int.Parse(String.Format("{0}", item.Tag)) == tag[1])
                {
                    if (check)
                    {
                        item.Enabled = false;
                        found++;
                    }
                    else
                    {
                        item.Image = Properties.Resources.corn1;
                        item.Refresh();
                    }
                }

            }
        }
    }
}