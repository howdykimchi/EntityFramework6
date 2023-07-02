namespace EntityFramework6
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
            lblStatus = new Label();
            btnTestConnection = new Button();
            btnCreateDatabase = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRead = new Button();
            btnCreate = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(145, 16);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status";
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(12, 12);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(127, 23);
            btnTestConnection.TabIndex = 9;
            btnTestConnection.Text = "Test Connection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // btnCreateDatabase
            // 
            btnCreateDatabase.Location = new Point(12, 41);
            btnCreateDatabase.Name = "btnCreateDatabase";
            btnCreateDatabase.Size = new Size(127, 23);
            btnCreateDatabase.TabIndex = 11;
            btnCreateDatabase.Text = "Create Database";
            btnCreateDatabase.UseVisualStyleBackColor = true;
            btnCreateDatabase.Click += btnCreateDatabase_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(12, 143);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 22;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 172);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(12, 114);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(127, 23);
            btnRead.TabIndex = 20;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 85);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(127, 23);
            btnCreate.TabIndex = 23;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 67);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 24;
            label1.Text = "CRUD";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnCreate);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnRead);
            Controls.Add(btnCreateDatabase);
            Controls.Add(lblStatus);
            Controls.Add(btnTestConnection);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Button btnTestConnection;
        private Button btnCreateDatabase;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRead;
        private Button btnCreate;
        private Label label1;
    }
}