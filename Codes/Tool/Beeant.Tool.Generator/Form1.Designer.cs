﻿namespace Beeant.Tool.Generator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSqlCon = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.cbSite = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTemplate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEntityNickname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRequiry = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileByteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Redundancy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsImage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAttachment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EnumType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ManyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAllowModify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsUnique = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsCloud = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsRemove = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库";
            // 
            // txtSqlCon
            // 
            this.txtSqlCon.Location = new System.Drawing.Point(102, 28);
            this.txtSqlCon.Name = "txtSqlCon";
            this.txtSqlCon.Size = new System.Drawing.Size(480, 21);
            this.txtSqlCon.TabIndex = 1;
            this.txtSqlCon.Text = "server=.\\SQL2016;uid=sa;pwd=1;database=Beeant;Pooling=true;";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1177, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "加载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(601, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "表";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(624, 30);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(190, 21);
            this.txtTable.TabIndex = 4;
            this.txtTable.Text = "t_";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Nickname,
            this.Type,
            this.Length,
            this.IsRequiry,
            this.FileByteName,
            this.Module,
            this.Redundancy,
            this.IsImage,
            this.IsAttachment,
            this.EnumType,
            this.ManyName,
            this.IsAllowModify,
            this.IsUnique,
            this.IsCloud,
            this.IsRemove,
            this.IsNull});
            this.dataGridView1.Location = new System.Drawing.Point(30, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1242, 281);
            this.dataGridView1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(507, 463);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbSite
            // 
            this.cbSite.FormattingEnabled = true;
            this.cbSite.Location = new System.Drawing.Point(102, 378);
            this.cbSite.Name = "cbSite";
            this.cbSite.Size = new System.Drawing.Size(121, 20);
            this.cbSite.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "添加站点";
            // 
            // cbTemplate
            // 
            this.cbTemplate.FormattingEnabled = true;
            this.cbTemplate.Location = new System.Drawing.Point(812, 386);
            this.cbTemplate.Name = "cbTemplate";
            this.cbTemplate.Size = new System.Drawing.Size(121, 20);
            this.cbTemplate.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(717, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "模板";
            // 
            // txtEntityNickname
            // 
            this.txtEntityNickname.Location = new System.Drawing.Point(901, 33);
            this.txtEntityNickname.Name = "txtEntityNickname";
            this.txtEntityNickname.Size = new System.Drawing.Size(190, 21);
            this.txtEntityNickname.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(840, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "实体说明";
            // 
            // Name
            // 
            this.Name.HeaderText = "名称";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Nickname
            // 
            this.Nickname.HeaderText = "中文";
            this.Nickname.Name = "Nickname";
            this.Nickname.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Length
            // 
            this.Length.HeaderText = "长度";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // IsRequiry
            // 
            this.IsRequiry.HeaderText = "是否必填";
            this.IsRequiry.Name = "IsRequiry";
            this.IsRequiry.ReadOnly = true;
            this.IsRequiry.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsRequiry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FileByteName
            // 
            this.FileByteName.HeaderText = "文件流名称";
            this.FileByteName.Name = "FileByteName";
            this.FileByteName.ReadOnly = true;
            this.FileByteName.Width = 90;
            // 
            // Module
            // 
            this.Module.HeaderText = "关联模块";
            this.Module.Name = "Module";
            this.Module.ReadOnly = true;
            // 
            // Redundancy
            // 
            this.Redundancy.HeaderText = "冗余属性";
            this.Redundancy.Name = "Redundancy";
            this.Redundancy.ReadOnly = true;
            // 
            // IsImage
            // 
            this.IsImage.HeaderText = "是否图片";
            this.IsImage.Name = "IsImage";
            this.IsImage.ReadOnly = true;
            // 
            // IsAttachment
            // 
            this.IsAttachment.HeaderText = "是否附件";
            this.IsAttachment.Name = "IsAttachment";
            this.IsAttachment.ReadOnly = true;
            // 
            // EnumType
            // 
            this.EnumType.HeaderText = "枚举类型";
            this.EnumType.Name = "EnumType";
            this.EnumType.ReadOnly = true;
            // 
            // ManyName
            // 
            this.ManyName.HeaderText = "Map实体名";
            this.ManyName.Name = "ManyName";
            this.ManyName.ReadOnly = true;
            // 
            // IsAllowModify
            // 
            this.IsAllowModify.HeaderText = "是否允许修改";
            this.IsAllowModify.Name = "IsAllowModify";
            this.IsAllowModify.ReadOnly = true;
            this.IsAllowModify.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsAllowModify.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsAllowModify.Width = 120;
            // 
            // IsUnique
            // 
            this.IsUnique.HeaderText = "是否唯一";
            this.IsUnique.Name = "IsUnique";
            this.IsUnique.ReadOnly = true;
            this.IsUnique.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsUnique.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsCloud
            // 
            this.IsCloud.HeaderText = "是否分区属性";
            this.IsCloud.Name = "IsCloud";
            this.IsCloud.ReadOnly = true;
            this.IsCloud.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCloud.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsCloud.Width = 120;
            // 
            // IsRemove
            // 
            this.IsRemove.HeaderText = "存在不能删除";
            this.IsRemove.Name = "IsRemove";
            this.IsRemove.ReadOnly = true;
            this.IsRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsRemove.Width = 120;
            // 
            // IsNull
            // 
            this.IsNull.HeaderText = "是否关联Id为0";
            this.IsNull.Name = "IsNull";
            this.IsNull.ReadOnly = true;
            this.IsNull.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsNull.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsNull.Width = 120;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 539);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEntityNickname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTemplate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSite);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSqlCon);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            //this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSqlCon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbSite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEntityNickname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRequiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileByteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Module;
        private System.Windows.Forms.DataGridViewTextBoxColumn Redundancy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsImage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAttachment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnumType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManyName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAllowModify;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsUnique;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCloud;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRemove;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNull;
    }
}

