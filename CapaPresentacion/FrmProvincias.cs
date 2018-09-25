using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FrmProvincias : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmProvincias()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txt_Provincia, "Ingresar el nombre de la provincia.");
        }

        //Mostrar mensaje de Confirmación
        private void MensageOk(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Prestamos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Mostrar mensaje de Error
        private void MensageError(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Prestamos", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //Limpiar
        private void Limpiar()
        {
            this.txt_Codigo.Text = string.Empty;
            this.txt_Provincia.Text = string.Empty;
           
        }

        //habilitar
        private void Habilitar(bool valor)
        {
            this.txt_Provincia.ReadOnly = !valor;
            this.txt_Codigo.ReadOnly = !valor;
            
        }
        //habilitar botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btn_Nuevo.Enabled = false;
                this.btn_Guardar.Enabled = true;
                this.btn_Editar.Enabled = false;
                this.btn_Cancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btn_Nuevo.Enabled = true;
                this.btn_Guardar.Enabled = false;
                this.btn_Editar.Enabled = true;
                this.btn_Cancelar.Enabled = false;
            }
        }

        //Metodo Ocultar columnas
        private void Ocultar_Columnas()
        {
            this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[1].Visible = false;
        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProvincias.Mostrar();
            this.Ocultar_Columnas();
            this.lbl_Total.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
            dataListado.Columns[2].Width=100;
        }

        //Metodo Buscar Nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProvincias.BuscarNombre(this.txt_Buscar.Text);
            this.Ocultar_Columnas();
            this.lbl_Total.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
        }

        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmProvincias_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txt_Provincia.Focus();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txt_Provincia.Text == string.Empty)
                {
                    MensageError("Faltan ingresar Datos");
                    errorIcono.SetError(txt_Provincia, "Ingrese una Provincia");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProvincias.Insertar(this.txt_Provincia.Text.Trim().ToUpper());

                    }
                    else
                    {
                        rpta = NProvincias.Editar(Convert.ToInt32(txt_Codigo.Text),
                        this.txt_Provincia.Text.Trim().ToUpper());
                        
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensageOk("Se Inseto de Forma Correcta");
                        }
                        else
                        {
                            this.MensageOk("Se Actualizo de Forma Correcta");
                        }
                    }
                    else
                    {
                        this.MensageError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txt_Codigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo_provincia"].Value);
            this.txt_Provincia.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["provincia"].Value);


            this.tabControl1.SelectedIndex = 1;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (!txt_Codigo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

            }
            else
            {
                this.MensageError("Debe de selecionar el registro a editar");
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void Cb_Eliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Eliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;

            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                     foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        

                        if(Convert.ToBoolean(row.Cells[0].Value)){
                            Codigo = Convert.ToString(row.Cells[1].Value);
                        Rpta = NProvincias.Eliminar(Convert.ToInt32(Codigo));
                        }
                        if (Rpta.Equals("OK"))
                        {
                            this.MensageOk("Se Elimino Correctamente el Registro");
                        }
                        else
                        {
                            this.MensageError(Rpta);
                        }

                    }
                    
                }
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        } 

        }
    }

