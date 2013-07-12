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
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        ConnectorClass cc;
        DataTable dt;

        private void FormAbmRolLoad(object sender, EventArgs e) {
            //MUESTRA LAS FUNCIONALIDADES QUE SE PUEDEN ESCOGER PARA DICHO ROL NUEVO
            cc = ConnectorClass.Instance;
            dt = cc.executeQuery("SELECT FUNCIONALIDAD_ID, FUNCIONALIDAD_NOMBRE FROM BUGDEVELOPING.FUNCIONALIDAD");
            checkedListBoxFuncionalidades.DataSource = dt;
            checkedListBoxFuncionalidades.DisplayMember = "FUNCIONALIDAD_NOMBRE";
            checkedListBoxFuncionalidades.ValueMember = "FUNCIONALIDAD_ID";
        }


        private void buttonAgregarRol(object sender, EventArgs e) { 
            //AGREGA EL ROL
            if(textBoxNombreRol.Text.Equals("")){
                //VALIDA SI EL NOMBRE ES CORRECTO
            
                MessageBox.Show("El nombre no puede ser vacío");
            }else{

                if (checkedListBoxFuncionalidades.CheckedItems.Count == 0)
                    //VALIDA LA CANTIDAD DE FUNCIONALIDADES ESCOGIDAS
                {
                    MessageBox.Show("Debe seleccionar al menos una funcionalidad");
                }
                else {
                    //INSERTA EN LA BASE EL NUEVO ROL
                    cc.executeQuery("insert into BUGDEVELOPING.ROL (ROL_NOMBRE,ROL_TIPO,ROL_HABILITACION) values ('"+textBoxNombreRol.Text+"',1,1)");
                     dt = cc.executeQuery("select ROL_ID FROM BUGDEVELOPING.ROL  WHERE ( ROL_NOMBRE = '"+textBoxNombreRol.Text+"')");
                    String idRolCreado = dt.Rows[0].ItemArray[0].ToString();
                    foreach (DataRowView FilaSeleccionados in checkedListBoxFuncionalidades.CheckedItems)
                    {   //INGRESA EN LA BASE PARA LA TABLA FUN/ROL
                        String strFunCod = FilaSeleccionados["FUNCIONALIDAD_ID"].ToString();
                        cc.executeQuery("INSERT INTO BUGDEVELOPING.FUNROL (FUNROL_FUNCIONALIDAD_ID,FUNROL_ROL_ID) VALUES (" + strFunCod + "," + idRolCreado + ")");
                    }

                    MessageBox.Show("Rol Creado Exitosamente");
                }

            }
        
        }

        private void buttonLimpiarSeleccion(object sender, EventArgs e) {
            //LIMPIA LA SELECECCION DE FUNCIONALIDADES
            foreach (int index in checkedListBoxFuncionalidades.CheckedIndices)
            {
                checkedListBoxFuncionalidades.SetItemChecked(index, false);
            }
            textBoxNombreRol.Text = "";
            textBoxNombreRol.Focus();

        }
    }
}
