using SharedModels;
using SharedModels.Dto;
using SharedModels.Dto.DeduccionesDto;
using SharedModels.Dto.EmpleadoDto;
using SharedModels.Dto.IngresosDto;
using SharedModels.Dto.NominaDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tarea_de_curso_2M1_is
{
    public partial class CRUDForm : Form
    {
        private readonly ApiClient _apiClient;
        private Principal Principal;

        public CRUDForm(ApiClient apiClient, Principal formPrincipal)
        {
            InitializeComponent();
            _apiClient = apiClient;
            Principal = formPrincipal;
            picture_load.Visible = false;

        }

        private async void cmb_tablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            picture_load.Visible = true;
            if (cmb_tablas.SelectedIndex == 0)
            {
                dtgvTablas.DataSource = null;
                dtgvTablas.DataSource = await _apiClient.empleados.GetAllAsync();
                picture_load.Visible = false;
                cmb_elemntos.Items.Clear();
                LlenarComboBoxConAtributos<empleadoComboBoxDto>(cmb_elemntos);
                btnModificar.Enabled = true;
                cmb_elemntos.Enabled = true;
                btnBorrar.Enabled = true;
                txt_cambio.Enabled = true;

            }
            else if (cmb_tablas.SelectedIndex == 1)
            {
                dtgvTablas.DataSource = null;
                dtgvTablas.DataSource = await _apiClient.ingresos.GetAllAsync();
                picture_load.Visible = false;
                cmb_elemntos.Items.Clear();
                LlenarComboBoxConAtributos<IngresosComboxDto>(cmb_elemntos);
                btnModificar.Enabled = true;
                cmb_elemntos.Enabled = true;
                btnBorrar.Enabled = true;
                txt_cambio.Enabled = true;
            }
            else if (cmb_tablas.SelectedIndex == 2)
            {
                dtgvTablas.DataSource = null;
                dtgvTablas.DataSource = await _apiClient.deducciones.GetAllAsync();
                picture_load.Visible = false;
                cmb_elemntos.Items.Clear();
                LlenarComboBoxConAtributos<DeduccionesComboboxDto>(cmb_elemntos);
                btnModificar.Enabled = true;
                cmb_elemntos.Enabled = true;
                btnBorrar.Enabled = true;
                txt_cambio.Enabled = true;
            }
            else if (cmb_tablas.SelectedIndex == 3)
            {
                dtgvTablas.DataSource = null;
                dtgvTablas.DataSource = await _apiClient.nominas.GetAllAsync();
                picture_load.Visible = false;
                btnModificar.Enabled = false;
                cmb_elemntos.Enabled = false;
                btnBorrar.Enabled = false;
                txt_cambio.Enabled = false;
                btnModificar_Click(sender, e);
            }
            else
            {
                dtgvTablas.DataSource = null;
                dtgvTablas.DataSource = await _apiClient.actividades.GetAllAsync();
                picture_load.Visible = false;
                btnModificar.Enabled = false;
                cmb_elemntos.Enabled = false;
                btnBorrar.Enabled = false;
                txt_cambio.Enabled = false;
            }
        }

        private int GetIdSeleccionado(DataGridView data)
        {
            if (data.SelectedRows.Count > 0 &&
                data.SelectedRows[0].Cells[0].Value != null)
            {
                return Convert.ToInt32(data.SelectedRows[0].Cells[0].Value);
            }
            return -5;
        }

        private async void txtBorrar_Click(object sender, EventArgs e)
        {
            int id = GetIdSeleccionado(dtgvTablas);

            if (id == -5)
            {
                MessageBox.Show("Seleccione la entidad a eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmb_tablas.SelectedIndex == 0)
            {
                await EliminandoTodoDeEmpleado(id);
               
                MessageBox.Show("Se elimino el empleado seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cmb_tablas.SelectedIndex == 1)
            {
                await _apiClient.ingresos.DeleteAsync(id);
                MessageBox.Show("Se elimino el ingreso seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cmb_tablas.SelectedIndex == 2)
            {
                await _apiClient.deducciones.DeleteAsync(id);
                MessageBox.Show("Se elimino la deduccion seleccionada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cmb_tablas.SelectedIndex == 3)
            {
                await _apiClient.nominas.DeleteAsync(id);
                MessageBox.Show("Se elimino el la nomina seleccionada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna tabla");
            }

            cmb_tablas_SelectedIndexChanged(sender, e);

        }

        private async Task EliminandoTodoDeEmpleado(int id)
        {
            _apiClient.empleados.DeleteAsync(id);
            
            _apiClient.ingresos.DeleteAsync(id);
            
            _apiClient.deducciones.DeleteAsync(id);
            
            _apiClient.nominas.DeleteAsync(id);
        }

        bool nuevaNomina = false;
        int id = 0;
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (cmb_tablas.SelectedIndex == 3)
            {
                NuevaNomina(nuevaNomina,id,sender,e);
                return;
            }

            if (cmb_elemntos.SelectedIndex == -1 || string.IsNullOrEmpty(txt_cambio.Text))
            {
                MessageBox.Show("Por favor, selecciona un atributo e ingresa un nuevo valor." , "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            id = GetIdSeleccionado(dtgvTablas);
            if (id == -5)
            {
                MessageBox.Show("NO se ha seleccionado ningun id, de tabla, por favor seleccionarlo","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            int op = -1;
            if (cmb_tablas.SelectedIndex == 0)
            {  
                op = 0;
            }
            else if (cmb_tablas.SelectedIndex == 1)
            {
                
                op = 1;
            }
            else if (cmb_tablas.SelectedIndex == 2)
            {
                op = 2;
              
            }

            string nuevoValor = txt_cambio.Text;

          
            try
            {
                switch (op)
                {
                    case 0:

                        var empleadoSeleccionado = (EmpleadoReadDto)dtgvTablas.SelectedRows[0].DataBoundItem;
                        var nuevo = new EmpleadoUpdateDto
                        {
                            EmpleadoId = empleadoSeleccionado.EmpleadoId,
                            primerNombre = empleadoSeleccionado.primerNombre,
                            segundoNombre = empleadoSeleccionado.segundoNombre,
                            primerApellido = empleadoSeleccionado.primerApellido,
                            segundoApellido = empleadoSeleccionado.segundoApellido,
                            numCedula = empleadoSeleccionado.numCedula,
                            numInss = empleadoSeleccionado.numInss,
                            numRuc = empleadoSeleccionado.numRuc,
                            sexo = empleadoSeleccionado.sexo,
                            fechaDeNacimiento = empleadoSeleccionado.fechaDeNacimiento,
                            fechaDeContratacion = empleadoSeleccionado.fechaDeContratacion,
                            fechaDeCierreDeContrato = empleadoSeleccionado.fechaDeCierreDeContrato,
                            estado = empleadoSeleccionado.estado
                        };
                        if (cmb_elemntos.SelectedIndex == 0)
                        {
                            nuevo.estadoCivil = nuevoValor;
                            nuevo.direccion = empleadoSeleccionado.direccion;
                            nuevo.telefono = empleadoSeleccionado.telefono;
                            nuevo.celular = empleadoSeleccionado.celular;
                        }
                        else if (cmb_elemntos.SelectedIndex == 1)
                        {
                            nuevo.direccion = nuevoValor;
                            nuevo.estadoCivil = empleadoSeleccionado.estadoCivil;
                            nuevo.telefono = empleadoSeleccionado.telefono;
                            nuevo.celular = empleadoSeleccionado.celular;
                        }
                        else if (cmb_elemntos.SelectedIndex == 2)
                        {
                            nuevo.telefono = long.Parse(nuevoValor);
                            nuevo.direccion = empleadoSeleccionado.direccion;
                            nuevo.estadoCivil = empleadoSeleccionado.estadoCivil;
                            nuevo.celular = empleadoSeleccionado.celular;
                        }
                        else if (cmb_elemntos.SelectedIndex == 3)
                        {
                            nuevo.celular = long.Parse(nuevoValor);
                            nuevo.direccion = empleadoSeleccionado.direccion;
                            nuevo.telefono = empleadoSeleccionado.telefono;
                            nuevo.estadoCivil = empleadoSeleccionado.estadoCivil;
                        }


                        await _apiClient.empleados.UpdateAsync(empleadoSeleccionado.EmpleadoId, nuevo);


                        break;

                    case 1:

                        var ingresosSeleccionado = (IngresosReadDto)dtgvTablas.SelectedRows[0].DataBoundItem;

                        var nuevo2 = new IngresosUpdateDto
                        {
                            IngresoId = ingresosSeleccionado.IngresosId,
                            EmpleadoId = ingresosSeleccionado.EmpleadoId,
                            nombreDeEmpleado = ingresosSeleccionado.nombreDeEmpleado,
                            ApellidoDeEmpleado = ingresosSeleccionado.ApellidoDeEmpleado,                       
                        };

                        if (cmb_elemntos.SelectedIndex == 0)
                        {
                            nuevo2.SalarioBase = decimal.Parse(nuevoValor);
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.Comisiones = ingresosSeleccionado.Comisiones;
                            nuevo2.HorasExtra = ingresosSeleccionado.HorasExtra;
                            nuevo2.Bonificaciones = ingresosSeleccionado.Bonificaciones;
                            nuevo2.DepreciacionVehiculo = ingresosSeleccionado.DepreciacionVehiculo;
                            nuevo2.ViaticoCombustible = ingresosSeleccionado.ViaticoCombustible;
                            nuevo2.ViaticoAlimenticio = ingresosSeleccionado.ViaticoAlimenticio;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.RiesgoLaboral = ingresosSeleccionado.RiesgoLaboral;
                            nuevo2.OtrosIngresos = ingresosSeleccionado.OtrosIngresos;
                        }
                        else if (cmb_elemntos.SelectedIndex == 1)
                        {
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.SalarioBase = ingresosSeleccionado.SalarioBase;
                            nuevo2.HorasExtra = ingresosSeleccionado.HorasExtra;
                            nuevo2.Bonificaciones = ingresosSeleccionado.Bonificaciones;
                            nuevo2.DepreciacionVehiculo = ingresosSeleccionado.DepreciacionVehiculo;
                            nuevo2.ViaticoCombustible = ingresosSeleccionado.ViaticoCombustible;
                            nuevo2.ViaticoAlimenticio = ingresosSeleccionado.ViaticoAlimenticio;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.RiesgoLaboral = ingresosSeleccionado.RiesgoLaboral;
                            nuevo2.OtrosIngresos = ingresosSeleccionado.OtrosIngresos;
                        }
                        else if (cmb_elemntos.SelectedIndex == 2)
                        {
                            nuevo2.HorasExtra = int.Parse(nuevoValor);
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.SalarioBase = ingresosSeleccionado.SalarioBase;
                            nuevo2.Comisiones = ingresosSeleccionado.Comisiones;
                            nuevo2.Bonificaciones = ingresosSeleccionado.Bonificaciones;
                            nuevo2.DepreciacionVehiculo = ingresosSeleccionado.DepreciacionVehiculo;
                            nuevo2.ViaticoCombustible = ingresosSeleccionado.ViaticoCombustible;
                            nuevo2.ViaticoAlimenticio = ingresosSeleccionado.ViaticoAlimenticio;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.RiesgoLaboral = ingresosSeleccionado.RiesgoLaboral;
                            nuevo2.OtrosIngresos = ingresosSeleccionado.OtrosIngresos;
                        }
                        else if (cmb_elemntos.SelectedIndex == 3)
                        {
                            nuevo2.Bonificaciones = decimal.Parse(nuevoValor);
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.SalarioBase = ingresosSeleccionado.SalarioBase;
                            nuevo2.Comisiones = ingresosSeleccionado.Comisiones;
                            nuevo2.HorasExtra = ingresosSeleccionado.HorasExtra;
                            nuevo2.DepreciacionVehiculo = ingresosSeleccionado.DepreciacionVehiculo;
                            nuevo2.ViaticoCombustible = ingresosSeleccionado.ViaticoCombustible;
                            nuevo2.ViaticoAlimenticio = ingresosSeleccionado.ViaticoAlimenticio;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.RiesgoLaboral = ingresosSeleccionado.RiesgoLaboral;
                            nuevo2.OtrosIngresos = ingresosSeleccionado.OtrosIngresos;
                        }
                        else if (cmb_elemntos.SelectedIndex == 4)
                        {
                            nuevo2.DepreciacionVehiculo = decimal.Parse(nuevoValor);
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.SalarioBase = ingresosSeleccionado.SalarioBase;
                            nuevo2.Comisiones = ingresosSeleccionado.Comisiones;
                            nuevo2.HorasExtra = ingresosSeleccionado.HorasExtra;
                            nuevo2.Bonificaciones = ingresosSeleccionado.Bonificaciones;
                            nuevo2.ViaticoCombustible = ingresosSeleccionado.ViaticoCombustible;
                            nuevo2.ViaticoAlimenticio = ingresosSeleccionado.ViaticoAlimenticio;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.RiesgoLaboral = ingresosSeleccionado.RiesgoLaboral;
                            nuevo2.OtrosIngresos = ingresosSeleccionado.OtrosIngresos;
                        }
                        else if (cmb_elemntos.SelectedIndex == 5)
                        {
                            nuevo2.ViaticoCombustible = decimal.Parse(nuevoValor);
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.SalarioBase = ingresosSeleccionado.SalarioBase;
                            nuevo2.Comisiones = ingresosSeleccionado.Comisiones;
                            nuevo2.HorasExtra = ingresosSeleccionado.HorasExtra;
                            nuevo2.Bonificaciones = ingresosSeleccionado.Bonificaciones;
                            nuevo2.DepreciacionVehiculo = ingresosSeleccionado.DepreciacionVehiculo;
                            nuevo2.ViaticoAlimenticio = ingresosSeleccionado.ViaticoAlimenticio;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.RiesgoLaboral = ingresosSeleccionado.RiesgoLaboral;
                            nuevo2.OtrosIngresos = ingresosSeleccionado.OtrosIngresos;
                        }
                        else if (cmb_elemntos.SelectedIndex == 6)
                        {
                            nuevo2.ViaticoAlimenticio = decimal.Parse(nuevoValor);
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.SalarioBase = ingresosSeleccionado.SalarioBase;
                            nuevo2.Comisiones = ingresosSeleccionado.Comisiones;
                            nuevo2.HorasExtra = ingresosSeleccionado.HorasExtra;
                            nuevo2.Bonificaciones = ingresosSeleccionado.Bonificaciones;
                            nuevo2.DepreciacionVehiculo = ingresosSeleccionado.DepreciacionVehiculo;
                            nuevo2.ViaticoCombustible = ingresosSeleccionado.ViaticoCombustible;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.RiesgoLaboral = ingresosSeleccionado.RiesgoLaboral;
                            nuevo2.OtrosIngresos = ingresosSeleccionado.OtrosIngresos;
                        }
                        else if (cmb_elemntos.SelectedIndex == 7)
                        {
                            nuevo2.RiesgoLaboral = decimal.Parse(nuevoValor);
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.SalarioBase = ingresosSeleccionado.SalarioBase;
                            nuevo2.Comisiones = ingresosSeleccionado.Comisiones;
                            nuevo2.HorasExtra = ingresosSeleccionado.HorasExtra;
                            nuevo2.Bonificaciones = ingresosSeleccionado.Bonificaciones;
                            nuevo2.DepreciacionVehiculo = ingresosSeleccionado.DepreciacionVehiculo;
                            nuevo2.ViaticoCombustible = ingresosSeleccionado.ViaticoCombustible;
                            nuevo2.ViaticoAlimenticio = ingresosSeleccionado.ViaticoAlimenticio;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.OtrosIngresos = ingresosSeleccionado.OtrosIngresos;
                        }
                        else if (cmb_elemntos.SelectedIndex == 8)
                        {
                            nuevo2.OtrosIngresos = decimal.Parse(nuevoValor);
                            nuevo2.Comisiones = decimal.Parse(nuevoValor);
                            nuevo2.SalarioBase = ingresosSeleccionado.SalarioBase;
                            nuevo2.Comisiones = ingresosSeleccionado.Comisiones;
                            nuevo2.HorasExtra = ingresosSeleccionado.HorasExtra;
                            nuevo2.Bonificaciones = ingresosSeleccionado.Bonificaciones;
                            nuevo2.DepreciacionVehiculo = ingresosSeleccionado.DepreciacionVehiculo;
                            nuevo2.ViaticoCombustible = ingresosSeleccionado.ViaticoCombustible;
                            nuevo2.ViaticoAlimenticio = ingresosSeleccionado.ViaticoAlimenticio;
                            nuevo2.ViaticoPorHospedaje = ingresosSeleccionado.ViaticoPorHospedaje;
                            nuevo2.RiesgoLaboral = ingresosSeleccionado.RiesgoLaboral;
                        }
                        var hecho2 = await _apiClient.ingresos.UpdateAsync(ingresosSeleccionado.IngresosId, nuevo2);
                        nuevaNomina = true;
                        break;

                    case 2:
                       

                        var deduccionesSeleccionado = (DeduccionesReadDto)dtgvTablas.SelectedRows[0].DataBoundItem;
                        var nuevo3 = new DeduccionesUpdateDto
                        {
                            DeduccionId = deduccionesSeleccionado.deduccionesId ,
                            empleadoId = deduccionesSeleccionado.empleadoId,
                            nombreDeEmpleado = deduccionesSeleccionado.nombreDeEmpleado,
                            ApellidoDeEmpleado = deduccionesSeleccionado.ApellidoDeEmpleado,
                            
                        };

                        if (cmb_elemntos.SelectedIndex == 0)
                        {
                            nuevo3.PrestamoBancario = decimal.Parse(nuevoValor);
                            nuevo3.PrestamoEmpresario = deduccionesSeleccionado.PrestamoEmpresario;
                            nuevo3.PensionAlimenticia = deduccionesSeleccionado.PensionAlimenticia;
                            nuevo3.DeduccionPorDaños = deduccionesSeleccionado.DeduccionPorDaños;
                            nuevo3.despreciacionVehiculo = deduccionesSeleccionado.despreciacionVehiculo;
                        }
                        else if (cmb_elemntos.SelectedIndex == 1)
                        {
                            nuevo3.PrestamoEmpresario = decimal.Parse(nuevoValor);
                            nuevo3.PrestamoBancario = deduccionesSeleccionado.PrestamoBancario;

                            nuevo3.PensionAlimenticia = deduccionesSeleccionado.PensionAlimenticia;
                            nuevo3.DeduccionPorDaños = deduccionesSeleccionado.DeduccionPorDaños;
                            nuevo3.despreciacionVehiculo = deduccionesSeleccionado.despreciacionVehiculo;
                        }
                        else if (cmb_elemntos.SelectedIndex == 2)
                        {
                            nuevo3.PensionAlimenticia = int.Parse(nuevoValor);
                            nuevo3.PrestamoBancario = deduccionesSeleccionado.PrestamoBancario;
                            nuevo3.PrestamoEmpresario = deduccionesSeleccionado.PrestamoEmpresario;

                            nuevo3.DeduccionPorDaños = deduccionesSeleccionado.DeduccionPorDaños;
                            nuevo3.despreciacionVehiculo = deduccionesSeleccionado.despreciacionVehiculo;
                        }   
                        else if (cmb_elemntos.SelectedIndex == 3)
                        {
                            nuevo3.DeduccionPorDaños = decimal.Parse(nuevoValor);
                            nuevo3.PrestamoBancario = deduccionesSeleccionado.PrestamoBancario;
                            nuevo3.PrestamoEmpresario = deduccionesSeleccionado.PrestamoEmpresario;
                            nuevo3.PensionAlimenticia = deduccionesSeleccionado.PensionAlimenticia;
                            nuevo3.despreciacionVehiculo = deduccionesSeleccionado.despreciacionVehiculo;
                        }
                
                        await _apiClient.deducciones.UpdateAsync(deduccionesSeleccionado.deduccionesId, nuevo3);
                        nuevaNomina = true;
                        break;

                    
                 }


                
                        cmb_tablas_SelectedIndexChanged(sender, e);
            }
            catch (Exception)
            {

                MessageBox.Show("Sucedio un errror al momento de modificar un elemento","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private async void NuevaNomina(bool nuevaNo,int id, object sender,EventArgs e)
        {

            if (nuevaNo)
            {
                var DeduccionUpdate = await _apiClient.deducciones.GetByIdAsync(id);
                var IngresoUpdate = await _apiClient.ingresos.GetByIdAsync(id);


                var formAux = new Nominas(Principal, _apiClient);
                decimal? IngresoNeto = formAux.CalcularIngreso(IngresoUpdate.SalarioBase, IngresoUpdate.Comisiones, IngresoUpdate.ViaticoAlimenticio, IngresoUpdate.RiesgoLaboral, IngresoUpdate.OtrosIngresos, IngresoUpdate.HorasExtra);
                var nue = new NominaUpdateDto
                {
                    NominaId = id,
                    EmpleadoId = id,
                    NombreDeEmpleado = IngresoUpdate.nombreDeEmpleado,
                    ApellidoDeEmpleado = IngresoUpdate.ApellidoDeEmpleado,
                    inns = formAux.calcular(IngresoNeto, "inss"),
                    ir = formAux.calcular(IngresoNeto, "Irr"),
                    SalarioFinal = await formAux.CalcularSalarioNetoAsync(DeduccionUpdate.DeduccionPorDaños, DeduccionUpdate.PensionAlimenticia, DeduccionUpdate.PrestamoEmpresario,
                    DeduccionUpdate.PrestamoBancario, IngresoUpdate.ViaticoPorHospedaje, IngresoUpdate.ViaticoAlimenticio, IngresoUpdate.Bonificaciones, IngresoUpdate.ViaticoCombustible, DeduccionUpdate.despreciacionVehiculo,
                    IngresoUpdate.OtrosIngresos, IngresoUpdate.RiesgoLaboral, IngresoUpdate.Comisiones, IngresoUpdate.HorasExtra, IngresoUpdate.SalarioBase)

                };

                nuevaNomina = false;
                await _apiClient.nominas.UpdateAsync(id, nue);
                cmb_tablas_SelectedIndexChanged(sender, e);

            }
        }

        private void LlenarComboBoxConAtributos<T>(ComboBox comboBox)
        {

            var propertyNames = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                         .Select(prop => prop.Name)
                                         .ToArray();
            comboBox.Items.AddRange(propertyNames);
        }





    }
}
