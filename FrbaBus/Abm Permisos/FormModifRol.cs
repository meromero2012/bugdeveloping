

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
    public partial class FormModifRol : BaseForm
    {
        public FormModifRol():
               base()
        {
            InitializeComponent();
        }

        public static int RolCodigo;
        public static string RolNombre;
        public static string RolActivo;
        ConnectorClass Cn;
        DataTable Dt;
        int TotFunc;


        private void FormModifRol_Load(object sender, EventArgs e)
        {
            txtbNombre.Text = RolNombre;
            //SETEA PARAMETROS DE ROL ACTIVO O INACTIVO
            if (RolActivo == "True")
            {
                cbActivo.Text = "Activo";
            }
            else
            {
                cbActivo.Text = "Desactivado";
            }

            //MUESTRA EL CONTEXTO ACTUAL DE FUNCIONALIDAD POR ROL

            Cn = ConnectorClass.Instance;
            Dt = Cn.executeQuery("SELECT FUNCIONALIDAD_ID, FUNCIONALIDAD_NOMBRE FROM BUGDEVELOPING.FUNCIONALIDAD");

            clbFuncionalidades.DataSource = Dt;
            clbFuncionalidades.DisplayMember = "FUNCIONALIDAD_NOMBRE";
            clbFuncionalidades.ValueMember = "FUNCIONALIDAD_ID";

            bool Existe;
            String CodFun;
            TotFunc = Convert.ToInt16(clbFuncionalidades.Items.Count.ToString());

            for (int i = 0; i < TotFunc; i++)
            {
                CodFun = Dt.Rows[i].ItemArray[0].ToString();
                Existe = FrbaBus.Abm_Permisos.FuncionesRol.existeFunEnRol(RolCodigo, CodFun);
                if (Existe)
                {
                    //ACTIVA EL CHECKBOX PARA LAS QUE YA ESTAN SETEADAS
                    clbFuncionalidades.SetItemChecked(i, true);
                }
            }
        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            //LIMPIA TODOS LOS CHECKBOXES DE FUNCIONALIDADES
            txtbNombre.Text = "";
            for (int i = 0; i < TotFunc; i++)
            {
                clbFuncionalidades.SetItemChecked(i, false);
            }
        }

        private void bModificar_Click(object sender, EventArgs e)
        {//MODIFICA UN ROL
            if (clbFuncionalidades.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un rol");
                //VERIFICA QUE HAYAS SELECCIONADO UN ROL
            }
            else
            {   //VERIFICA EL NOMBRE NUEVO DEL ROL
                if (txtbNombre.Text == "")
                {
                    MessageBox.Show("El rol debe tener un nombre");
                }
                else
                {
                    //Si no cambió el nombre
                    bool ModificarOk;
                    //Hay que verificar si cambió el nombre del rol
                    if (txtbNombre.Text == RolNombre)
                    {
                        ModificarOk = true;
                    }
                    //Si lo cambió hay que verificar que el nombre no esté repetido en la base
                    //sin contar al que tenía antes de cambiarlo
                    else
                    {
                        if (FrbaBus.Abm_Permisos.FuncionesRol.existeNombreRol(txtbNombre.Text) == false)
                            ModificarOk = true;
                        else
                            ModificarOk = false;
                    }

                    //Si es true es porque, o bien, no cambió el nombre, o lo cambió y no estaba en la base
                    if (ModificarOk == true)
                    {
                        if (cbActivo.Text == "Activo")
                        {
                            RolActivo = "1";
                        }
                        else
                        {
                            RolActivo = "0";
                            //Se quita todos el Rol a los Usuarios que lo tengan
                            FrbaBus.Abm_Permisos.FuncionesRol.borrarRolXUsuario(RolCodigo);
                        }
                        RolNombre = txtbNombre.Text;

                        FrbaBus.Abm_Permisos.FuncionesRol.modificarNombreYHabilitacion(RolCodigo, RolNombre, RolActivo);

                        /**Borra todos las funcionalidades asociadas al rol**/
                        FrbaBus.Abm_Permisos.FuncionesRol.borrarFuncionalidades(RolCodigo);

                        /**Inserta todas las funcionalidades clickeadas relacionandalas con el rol **/
                        foreach (DataRowView FilaSeleccionados in clbFuncionalidades.CheckedItems)
                        {
                            String strFunCod = FilaSeleccionados["FUNCIONALIDAD_ID"].ToString();
                            Cn.executeQuery("INSERT INTO BUGDEVELOPING.FUNROL (FUNROL_FUNCIONALIDAD_ID,FUNROL_ROL_ID) VALUES (" + strFunCod + "," + RolCodigo + ")");
                        }

                     

                        MessageBox.Show("Rol actualizado con éxito");
                        this.Close();
                    }
                    //Se le avisa al usuario que el nombre del rol ya existe
                    else
                    {
                        MessageBox.Show("El nombre de rol ya existe");
                    }
                }
            }

        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
