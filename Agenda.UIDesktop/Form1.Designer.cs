namespace Agenda.UIDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblContatoNovo = new Label();
            txtContatoNovo = new TextBox();
            lblContatoSalvo = new Label();
            txtContatoSalvo = new TextBox();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // lblContatoNovo
            // 
            lblContatoNovo.AutoSize = true;
            lblContatoNovo.Location = new Point(12, 9);
            lblContatoNovo.Name = "lblContatoNovo";
            lblContatoNovo.Size = new Size(80, 15);
            lblContatoNovo.TabIndex = 0;
            lblContatoNovo.Text = "Contato novo";
            // 
            // txtContatoNovo
            // 
            txtContatoNovo.Location = new Point(12, 27);
            txtContatoNovo.Name = "txtContatoNovo";
            txtContatoNovo.Size = new Size(301, 23);
            txtContatoNovo.TabIndex = 1;
            // 
            // lblContatoSalvo
            // 
            lblContatoSalvo.AutoSize = true;
            lblContatoSalvo.Location = new Point(11, 62);
            lblContatoSalvo.Name = "lblContatoSalvo";
            lblContatoSalvo.Size = new Size(81, 15);
            lblContatoSalvo.TabIndex = 2;
            lblContatoSalvo.Text = "Contato Salvo";
            // 
            // txtContatoSalvo
            // 
            txtContatoSalvo.Location = new Point(13, 82);
            txtContatoSalvo.Name = "txtContatoSalvo";
            txtContatoSalvo.Size = new Size(299, 23);
            txtContatoSalvo.TabIndex = 3;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(170, 123);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(143, 58);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalvar);
            Controls.Add(txtContatoSalvo);
            Controls.Add(lblContatoSalvo);
            Controls.Add(txtContatoNovo);
            Controls.Add(lblContatoNovo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContatoNovo;
        private TextBox txtContatoNovo;
        private Label lblContatoSalvo;
        private TextBox txtContatoSalvo;
        private Button btnSalvar;
    }
}