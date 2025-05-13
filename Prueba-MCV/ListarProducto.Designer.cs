using System.Windows.Forms;

namespace Prueba_MCV
{
    partial class ListarProducto
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.productoDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAbrirVenta = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnAbrirPedidos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productoDataGridView)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // productoDataGridView
            // 
            this.productoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel.SetColumnSpan(this.productoDataGridView, 2);
            this.productoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productoDataGridView.Location = new System.Drawing.Point(9, 102);
            this.productoDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.productoDataGridView.Name = "productoDataGridView";
            this.productoDataGridView.RowHeadersWidth = 62;
            this.productoDataGridView.RowTemplate.Height = 28;
            this.productoDataGridView.Size = new System.Drawing.Size(518, 227);
            this.productoDataGridView.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnAgregar.Location = new System.Drawing.Point(270, 8);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(257, 39);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(9, 6);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(257, 48);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Listado de productos";
            // 
            // btnAbrirVenta
            // 
            this.btnAbrirVenta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAbrirVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbrirVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirVenta.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnAbrirVenta.Location = new System.Drawing.Point(270, 56);
            this.btnAbrirVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirVenta.Name = "btnAbrirVenta";
            this.btnAbrirVenta.Size = new System.Drawing.Size(257, 39);
            this.btnAbrirVenta.TabIndex = 2;
            this.btnAbrirVenta.Text = "Ir a Ventas";
            this.btnAbrirVenta.UseVisualStyleBackColor = false;
            this.btnAbrirVenta.Click += new System.EventHandler(this.btnAbrirVenta_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.lblTitulo, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnAgregar, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnAbrirVenta, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.productoDataGridView, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnAbrirPedidos, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.21951F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.78049F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(536, 337);
            this.tableLayoutPanel.TabIndex = 4;
            this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint);
            // 
            // btnAbrirPedidos
            // 
            this.btnAbrirPedidos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAbrirPedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbrirPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPedidos.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnAbrirPedidos.Location = new System.Drawing.Point(9, 56);
            this.btnAbrirPedidos.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirPedidos.Name = "btnAbrirPedidos";
            this.btnAbrirPedidos.Size = new System.Drawing.Size(257, 39);
            this.btnAbrirPedidos.TabIndex = 3;
            this.btnAbrirPedidos.Text = "Ver Compras";
            this.btnAbrirPedidos.UseVisualStyleBackColor = false;
            this.btnAbrirPedidos.Click += new System.EventHandler(this.btnAbrirPedidos_click);
            // 
            // ListarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ListarProducto";
            this.Size = new System.Drawing.Size(536, 337);
            ((System.ComponentModel.ISupportInitialize)(this.productoDataGridView)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productoDataGridView;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAbrirVenta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnAbrirPedidos;
            
    }
}
