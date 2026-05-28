using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{

    public partial class frmVentas : Form
    {
        private Usuario _Usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }
        public frmVentas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";

            txtpagocon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {

                    txtdocumentocliente.Text = modal._Cliente.Documento;
                    txtnombrecliente.Text = modal._Cliente.NombreCompleto;
                    txtcodproducto.Select();
                }
                else
                {
                    txtdocumentocliente.Select();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidproducto.Text = modal._Producto.IdProducto.ToString();
                    txtcodproducto.Text = modal._Producto.Codigo;
                    txtproducto.Text = modal._Producto.Nombre;
                    txtprecio.Text = modal._Producto.PrecioVenta.ToString("0.00");
                    txtstock.Text = modal._Producto.Stock.ToString();
                    txtcantidad.Select();
                }
                else
                {
                    txtcodproducto.Select();
                }
            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtcodproducto.Text && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txtcodproducto.BackColor = System.Drawing.Color.Honeydew;
                    txtidproducto.Text = oProducto.IdProducto.ToString();
                    txtproducto.Text = oProducto.Nombre;
                    txtprecio.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtstock.Text = oProducto.Stock.ToString();
                    txtcantidad.Select();
                }

                else
                {
                    txtcodproducto.BackColor = System.Drawing.Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtproducto.Text = "";
                    txtprecio.Text = "0.00";
                    txtstock.Text = "0";
                    txtcantidad.Value = 1;
                }
            }
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtprecio.Text, out precio))
            {
                MessageBox.Show("Precio compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecio.Select();
                return;
            }
            if (Convert.ToInt32(txtstock.Text) < Convert.ToInt32(txtcantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor a el stock disponible", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                string mensaje = string.Empty;
                bool respuesta = new CN_Venta().RestarStock(
                     Convert.ToInt32(txtidproducto.Text), 
                     Convert.ToInt32(txtcantidad.Value.ToString()));
                if (respuesta)
                {
                    // Añadir valores con sus tipos reales (int, decimal) en lugar de strings
                    decimal subtotal = txtcantidad.Value * precio;
                    dgvdata.Rows.Add(new object[] {
                        Convert.ToInt32(txtidproducto.Text), // IdProducto (int)
                        txtproducto.Text,                    // Nombre (string)
                        precio,                              // Precio (decimal)
                        Convert.ToInt32(txtcantidad.Value),  // Cantidad (int)
                        subtotal                             // Subtotal (decimal)
                    });

                    calcularTotal();
                    limpiarproducto();
                    txtcodproducto.Select();
                }

                    
            }


        }
        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvdata.Rows)
                {
                    total += Convert.ToDecimal(fila.Cells["Subtotal"].Value.ToString());
                }
            }
            txttotalpagar.Text = total.ToString("0.00");
        }
        private void limpiarproducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "";
            txtstock.Text = "";
            txtcantidad.Value = 1;
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Imagen original
                var img = Properties.Resources.delete25;

                // Tamaño máximo permitido (celda)
                int maxWidth = e.CellBounds.Width - 4;  // Margen opcional
                int maxHeight = e.CellBounds.Height - 4;

                // Mantener proporción
                float ratio = Math.Min((float)maxWidth / img.Width, (float)maxHeight / img.Height);
                int drawWidth = (int)(img.Width * ratio);
                int drawHeight = (int)(img.Height * ratio);

                // Centrar imagen
                int x = e.CellBounds.Left + (e.CellBounds.Width - drawWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - drawHeight) / 2;

                e.Graphics.DrawImage(img, new Rectangle(x, y, drawWidth, drawHeight));
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    bool respuesta = new CN_Venta().SumarStock(
                     Convert.ToInt32(dgvdata.Rows[indice].Cells["IdProducto"].Value.ToString()),
                     Convert.ToInt32(dgvdata.Rows[indice].Cells["Cantidad"].Value.ToString()));


                    dgvdata.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtpagocon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpagocon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void calcularcambio()
        {
            if (txttotalpagar.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            decimal pagocon = 0;
            decimal total = Convert.ToDecimal(txttotalpagar.Text);

            if (txtpagocon.Text.Trim() == "")
            {
                txtpagocon.Text = "0";
            }
            if (decimal.TryParse(txtpagocon.Text.Trim(), out pagocon))
            {
                if (pagocon < total)
                {
                    txtcambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagocon - total;
                    txtcambio.Text = cambio.ToString("0.00");
                }
            }
            else
            {
                MessageBox.Show("Pago con - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagocon.Select();
            }
        }

        private void txtpagocon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                calcularcambio();
            }
        }

        private void btncrearventa_Click(object sender, EventArgs e)
        {
            if (txtdocumentocliente.Text == "")
            {
                MessageBox.Show("Debe seleccionar el documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtnombrecliente.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if(dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            DataTable detalle_venta = new DataTable();

            detalle_venta.Columns.Add("IdProducto", typeof(int));
            detalle_venta.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                detalle_venta.Rows.Add(new object[]
                {
                    row.Cells["IdProducto"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["Subtotal"].Value.ToString(),


                });
            }

            int idcorrelativo = new CN_Venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);
            calcularcambio();
            Venta oVenta = new Venta()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                TipoDocumento = ((OpcionCombo)cbotipodocumento.SelectedItem).Texto,
                NumeroDocumento = numeroDocumento,
                DocumentoCliente = txtdocumentocliente.Text,
                NombreCliente = txtnombrecliente.Text,
                MontoPago = Convert.ToDecimal(txtpagocon.Text),
                MontoCambio = Convert.ToDecimal(txtcambio.Text),
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oVenta,detalle_venta, out mensaje);

            respuesta = Convert.ToBoolean(respuesta);



            if (respuesta)
            {
                var result = MessageBox.Show("Numero de venta generada: " + numeroDocumento + "Desea copiar al portapapeles?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes) 
                    Clipboard.SetText(numeroDocumento);

                txtdocumentocliente.Text = "";
                txtnombrecliente.Text = "";
                dgvdata.Rows.Clear();
                calcularTotal();
                txtpagocon.Text = "";
                txtcambio.Text = "";

            }else 
              MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
