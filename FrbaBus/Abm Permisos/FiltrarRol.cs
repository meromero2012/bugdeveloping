using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;



namespace FrbaBus.Abm_Permisos
{
    public partial class FiltrarRol : Form
    {
        public FiltrarRol()
        {
            InitializeComponent();
        }

        ConnectorClass conn;

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            //LIMPIA LA SELECCION DE ROLES
            txtbNombre.Text = "";
            dgvRoles.DataSource = "";
            dgvRoles.Enabled = false;
            txtbNombre.Focus();
        }

        private void FormFiltrarRol_Load(object sender, EventArgs e)
        {

        }

        private void bFiltrar_Click(object sender, EventArgs e)
        {
            //TRAEL LOS ROLES SEGUN EL NOMBRE DE FILTRO
            conn = ConnectorClass.Instance;

            string seleccion = "Select ROL_ID,Rol_NOMBRE,ROL_TIPO,ROL_HABILITACION";
            string origen = " from BUGDEVELOPING.Rol";
            string condicion = " where 1=1";

            if (txtbNombre.Text != "")
            { condicion += " and ROL_NOMBRE like " + "'%" + txtbNombre.Text + "%'"; }

            dgvRoles.DataSource = conn.executeQuery(seleccion + origen + condicion);
            dgvRoles.Enabled = true;
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //INVOCA A LA ABM DE MODIFICACION DE ROLES SEGUN LOS ESCOGIDOS EN EL FILTRADO
            if ((dgvRoles.Rows.Count > 0) && (dgvRoles.Columns[e.ColumnIndex].HeaderText == "Seleccionar"))
            {
               FormModifRol form = new FormModifRol();
                FormModifRol.RolCodigo = Convert.ToInt16(dgvRoles.CurrentRow.Cells[1].Value.ToString());
                FormModifRol.RolNombre = dgvRoles.CurrentRow.Cells["ROL_NOMBRE"].Value.ToString();
                FormModifRol.RolActivo = dgvRoles.CurrentRow.Cells["ROL_HABILITACION"].Value.ToString();
                form.ShowDialog(this);
                                
            
            }
        }
    }
}
