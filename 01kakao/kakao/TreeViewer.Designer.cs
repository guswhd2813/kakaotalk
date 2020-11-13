namespace kakao
{
    partial class TreeViewer
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewer));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.kryptonTreeView = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "제가동(호실).jpg");
            // 
            // kryptonTreeView
            // 
            this.kryptonTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTreeView.Location = new System.Drawing.Point(0, 0);
            this.kryptonTreeView.Name = "kryptonTreeView";
            this.kryptonTreeView.Size = new System.Drawing.Size(363, 457);
            this.kryptonTreeView.TabIndex = 0;
            // 
            // TreeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonTreeView);
            this.Name = "TreeViewer";
            this.Size = new System.Drawing.Size(363, 457);
            this.Load += new System.EventHandler(this.TreeViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView kryptonTreeView;
    }
}
