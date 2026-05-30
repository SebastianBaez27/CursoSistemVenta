namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuusuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.Submenucategoria = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuproducto = new FontAwesome.Sharp.IconMenuItem();
            this.submenunegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuRegistrarventa = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuverdetalleventa = new FontAwesome.Sharp.IconMenuItem();
            this.menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuregistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuverdetallecompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuproveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.submenureportecompras = new System.Windows.Forms.ToolStripMenuItem();
            this.submenureporteventas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.btnsalir = new FontAwesome.Sharp.IconButton();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuarios,
            this.menumantenedor,
            this.menuventas,
            this.menucompras,
            this.menuclientes,
            this.menuproveedores,
            this.menureportes,
            this.menuacercade});
            this.menu.Location = new System.Drawing.Point(0, 84);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1095, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuusuarios
            // 
            this.menuusuarios.AutoSize = false;
            this.menuusuarios.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.menuusuarios.IconColor = System.Drawing.Color.Black;
            this.menuusuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuarios.IconSize = 50;
            this.menuusuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuarios.Name = "menuusuarios";
            this.menuusuarios.Size = new System.Drawing.Size(80, 69);
            this.menuusuarios.Text = "Usuarios";
            this.menuusuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuarios.Click += new System.EventHandler(this.menuusuarios_Click);
            // 
            // menumantenedor
            // 
            this.menumantenedor.AutoSize = false;
            this.menumantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Submenucategoria,
            this.Submenuproducto,
            this.submenunegocio});
            this.menumantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menumantenedor.IconColor = System.Drawing.Color.Black;
            this.menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenedor.IconSize = 50;
            this.menumantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenedor.Name = "menumantenedor";
            this.menumantenedor.Size = new System.Drawing.Size(152, 69);
            this.menumantenedor.Text = "Mantenedor";
            this.menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Submenucategoria
            // 
            this.Submenucategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenucategoria.IconColor = System.Drawing.Color.Black;
            this.Submenucategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenucategoria.Name = "Submenucategoria";
            this.Submenucategoria.Size = new System.Drawing.Size(157, 26);
            this.Submenucategoria.Text = "Categoria";
            this.Submenucategoria.Click += new System.EventHandler(this.Submenucategoria_Click);
            // 
            // Submenuproducto
            // 
            this.Submenuproducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuproducto.IconColor = System.Drawing.Color.Black;
            this.Submenuproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuproducto.Name = "Submenuproducto";
            this.Submenuproducto.Size = new System.Drawing.Size(157, 26);
            this.Submenuproducto.Text = "Producto";
            this.Submenuproducto.Click += new System.EventHandler(this.Submenuproducto_Click);
            // 
            // submenunegocio
            // 
            this.submenunegocio.Name = "submenunegocio";
            this.submenunegocio.Size = new System.Drawing.Size(157, 26);
            this.submenunegocio.Text = "Negocio";
            this.submenunegocio.Click += new System.EventHandler(this.submenunegocio_Click);
            // 
            // menuventas
            // 
            this.menuventas.AutoSize = false;
            this.menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmenuRegistrarventa,
            this.Submenuverdetalleventa});
            this.menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuventas.IconColor = System.Drawing.Color.Black;
            this.menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventas.IconSize = 50;
            this.menuventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventas.Name = "menuventas";
            this.menuventas.Size = new System.Drawing.Size(80, 69);
            this.menuventas.Text = "Ventas";
            this.menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubmenuRegistrarventa
            // 
            this.SubmenuRegistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuRegistrarventa.IconColor = System.Drawing.Color.Black;
            this.SubmenuRegistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuRegistrarventa.Name = "SubmenuRegistrarventa";
            this.SubmenuRegistrarventa.Size = new System.Drawing.Size(163, 26);
            this.SubmenuRegistrarventa.Text = "Registrar";
            this.SubmenuRegistrarventa.Click += new System.EventHandler(this.SubmenuRegistrarventa_Click);
            // 
            // Submenuverdetalleventa
            // 
            this.Submenuverdetalleventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuverdetalleventa.IconColor = System.Drawing.Color.Black;
            this.Submenuverdetalleventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuverdetalleventa.Name = "Submenuverdetalleventa";
            this.Submenuverdetalleventa.Size = new System.Drawing.Size(163, 26);
            this.Submenuverdetalleventa.Text = "Ver detalle";
            this.Submenuverdetalleventa.Click += new System.EventHandler(this.Submenuverdetalleventa_Click);
            // 
            // menucompras
            // 
            this.menucompras.AutoSize = false;
            this.menucompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Submenuregistrarcompra,
            this.Submenuverdetallecompra});
            this.menucompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menucompras.IconColor = System.Drawing.Color.Black;
            this.menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucompras.IconSize = 50;
            this.menucompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucompras.Name = "menucompras";
            this.menucompras.Size = new System.Drawing.Size(80, 69);
            this.menucompras.Text = "Compras";
            this.menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Submenuregistrarcompra
            // 
            this.Submenuregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuregistrarcompra.IconColor = System.Drawing.Color.Black;
            this.Submenuregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuregistrarcompra.Name = "Submenuregistrarcompra";
            this.Submenuregistrarcompra.Size = new System.Drawing.Size(163, 26);
            this.Submenuregistrarcompra.Text = "Registrar";
            this.Submenuregistrarcompra.Click += new System.EventHandler(this.Submenuregistrarcompra_Click);
            // 
            // Submenuverdetallecompra
            // 
            this.Submenuverdetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuverdetallecompra.IconColor = System.Drawing.Color.Black;
            this.Submenuverdetallecompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuverdetallecompra.Name = "Submenuverdetallecompra";
            this.Submenuverdetallecompra.Size = new System.Drawing.Size(163, 26);
            this.Submenuverdetallecompra.Text = "Ver detalle";
            this.Submenuverdetallecompra.Click += new System.EventHandler(this.Submenuverdetallecompra_Click);
            // 
            // menuclientes
            // 
            this.menuclientes.AutoSize = false;
            this.menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuclientes.IconColor = System.Drawing.Color.Black;
            this.menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuclientes.IconSize = 50;
            this.menuclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Size = new System.Drawing.Size(80, 69);
            this.menuclientes.Text = "Clientes";
            this.menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuclientes.Click += new System.EventHandler(this.menuclientes_Click);
            // 
            // menuproveedores
            // 
            this.menuproveedores.AutoSize = false;
            this.menuproveedores.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuproveedores.IconColor = System.Drawing.Color.Black;
            this.menuproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproveedores.IconSize = 50;
            this.menuproveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproveedores.Name = "menuproveedores";
            this.menuproveedores.Size = new System.Drawing.Size(152, 69);
            this.menuproveedores.Text = "Proveedores";
            this.menuproveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuproveedores.Click += new System.EventHandler(this.menuproveedores_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenureportecompras,
            this.submenureporteventas});
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.IconSize = 50;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(80, 69);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenureportecompras
            // 
            this.submenureportecompras.Name = "submenureportecompras";
            this.submenureportecompras.Size = new System.Drawing.Size(208, 26);
            this.submenureportecompras.Text = "Reporte Compras";
            this.submenureportecompras.Click += new System.EventHandler(this.submenureportecompras_Click);
            // 
            // submenureporteventas
            // 
            this.submenureporteventas.Name = "submenureporteventas";
            this.submenureporteventas.Size = new System.Drawing.Size(208, 26);
            this.submenureporteventas.Text = "Reporte Ventas";
            this.submenureporteventas.Click += new System.EventHandler(this.submenureporteventas_Click);
            // 
            // menuacercade
            // 
            this.menuacercade.AutoSize = false;
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuacercade.IconColor = System.Drawing.Color.Black;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.IconSize = 50;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.Size = new System.Drawing.Size(80, 69);
            this.menuacercade.Text = "Acerca de";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuacercade.Click += new System.EventHandler(this.menuacercade_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menutitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(1095, 84);
            this.menutitulo.TabIndex = 1;
            this.menutitulo.Text = "menuStrip2";
            this.menutitulo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menutitulo_ItemClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de ventas";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 157);
            this.contenedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1095, 519);
            this.contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(924, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(995, 26);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(71, 18);
            this.lblusuario.TabIndex = 5;
            this.lblusuario.Text = "lblusuario";
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btnsalir.IconColor = System.Drawing.Color.White;
            this.btnsalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsalir.Location = new System.Drawing.Point(848, 2);
            this.btnsalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(81, 66);
            this.btnsalir.TabIndex = 6;
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(1095, 676);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menucompras;
        private FontAwesome.Sharp.IconMenuItem menuproveedores;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private System.Windows.Forms.Panel contenedor;
        private FontAwesome.Sharp.IconMenuItem menuusuarios;
        private FontAwesome.Sharp.IconMenuItem menumantenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
        private FontAwesome.Sharp.IconMenuItem Submenucategoria;
        private FontAwesome.Sharp.IconMenuItem Submenuproducto;
        private FontAwesome.Sharp.IconMenuItem SubmenuRegistrarventa;
        private FontAwesome.Sharp.IconMenuItem Submenuverdetalleventa;
        private FontAwesome.Sharp.IconMenuItem Submenuregistrarcompra;
        private FontAwesome.Sharp.IconMenuItem Submenuverdetallecompra;
        private System.Windows.Forms.ToolStripMenuItem submenunegocio;
        private System.Windows.Forms.ToolStripMenuItem submenureportecompras;
        private System.Windows.Forms.ToolStripMenuItem submenureporteventas;
        private FontAwesome.Sharp.IconButton btnsalir;
    }
}

