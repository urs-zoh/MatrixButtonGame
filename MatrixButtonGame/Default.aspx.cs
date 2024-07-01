using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatrixButtonGame
{
    public partial class Default : System.Web.UI.Page
    {
        private static Random random = new Random();
        private const string MatrixSizeKey = "MatrixSize";
        private const string ScoreKey = "Score";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState[ScoreKey] = 0;
            }
            else
            {
                if (ViewState[MatrixSizeKey] != null)
                {
                    CreateMatrix((int)ViewState[MatrixSizeKey]);
                }
            }
        }
        protected void btnSize_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int size = int.Parse(btn.Text.Substring(0, 1));
            ViewState[MatrixSizeKey] = size;
            ViewState[ScoreKey] = 0;
            lblScore.Text = "Score: 0";
            CreateMatrix(size);
        }

        private void CreateMatrix(int size)
        {
            matrixContainer.Controls.Clear();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int value = random.Next(1, 10);
                    Button btn = new Button
                    {
                        Text = value.ToString(),
                        CssClass = "matrixButton",
                        ID = $"btn_{i}_{j}"
                    };
                    btn.Click += MatrixButton_Click;
                    matrixContainer.Controls.Add(btn);
                }
                matrixContainer.Controls.Add(new Literal { Text = "<br/>" });
            }
        }

        private void MatrixButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int currentScore = (int)ViewState[ScoreKey];
            int clickedValue = int.Parse(btn.Text);
            currentScore += clickedValue;
            lblScore.Text = $"Score: {currentScore}";

            if (currentScore == 10)
            {
                btn.Visible = false;
                ViewState[ScoreKey] = 0;
                lblScore.Text = "Score: 0";
            }
            else
            {
                ViewState[ScoreKey] = currentScore;
            }
        }
    }
}