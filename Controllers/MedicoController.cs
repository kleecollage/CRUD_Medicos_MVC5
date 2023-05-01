using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_de_medicos.Models;
using System.Configuration;
using System.Web.UI.WebControls;

namespace CRUD_de_medicos.Controllers
{
    public class MedicoController : Controller
    {

        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Medico> oLista = new List<Medico>();



        // GET: Medico
        public ActionResult Index()
        {
            oLista = new List<Medico>();

            using (SqlConnection oConexion = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM tblMedicos", oConexion);
                cmd.CommandType = CommandType.Text;
                oConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Medico nuevoMedico = new Medico();

                        nuevoMedico.pkMedicoID = Convert.ToInt32(dr["pkMedicoID"]);
                        nuevoMedico.Nombre = dr["Nombre"].ToString();
                        nuevoMedico.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                        nuevoMedico.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                        nuevoMedico.CedulaProfesional = dr["CedulaProfesional"].ToString();
                        nuevoMedico.fkEspecialidadID = Convert.ToInt32(dr["fkEspecialidadID"]);
                        nuevoMedico.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                        nuevoMedico.CrBy = Convert.ToInt32(dr["pkMedicoID"]);
                        nuevoMedico.CrDt = Convert.ToDateTime(dr["CrDt"]);


                        oLista.Add(nuevoMedico);

                    }
                }

            }

            return View(oLista);
        }




        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(Medico oMedico)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_Registrar", oConexion);

                cmd.Parameters.AddWithValue("Nombre", oMedico.Nombre);
                cmd.Parameters.AddWithValue("ApellidoPaterno", oMedico.ApellidoPaterno);
                cmd.Parameters.AddWithValue("ApellidoMaterno", oMedico.ApellidoMaterno);
                cmd.Parameters.AddWithValue("CedulaProfesional", oMedico.CedulaProfesional);
                cmd.Parameters.AddWithValue("fkEspecialidadID", oMedico.fkEspecialidadID);
                cmd.Parameters.AddWithValue("FechaNacimiento", oMedico.FechaNacimiento);
                cmd.Parameters.AddWithValue("CrBy", oMedico.CrBy);


                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Medico");
        }




        [HttpGet]
        public ActionResult Editar(int? idmedico)
        {
            if (idmedico == null)
                return RedirectToAction("Index", "Medico");

            Medico oMedico = oLista.Where(c => c.pkMedicoID == idmedico).FirstOrDefault();
            return View(oMedico);
        }


        [HttpPost]
        public ActionResult Editar(Medico oMedico)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Editar", oConexion);
                cmd.Parameters.AddWithValue("pkMedicoID", oMedico.pkMedicoID);
                cmd.Parameters.AddWithValue("Nombre", oMedico.Nombre);
                cmd.Parameters.AddWithValue("ApellidoPaterno", oMedico.ApellidoPaterno);
                cmd.Parameters.AddWithValue("ApellidoMaterno", oMedico.ApellidoMaterno);
                cmd.Parameters.AddWithValue("CedulaProfesional", oMedico.CedulaProfesional);
                cmd.Parameters.AddWithValue("fkEspecialidadID", oMedico.fkEspecialidadID);
                cmd.Parameters.AddWithValue("FechaNacimiento", oMedico.FechaNacimiento);
                cmd.Parameters.AddWithValue("CrBy", oMedico.CrBy);
                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Medico");
        }

        [HttpGet]
        public ActionResult Eliminar(int? idmedico)
        {
            if (idmedico == null)
                return RedirectToAction("Index", "Medico");


            Medico oMedico = oLista.Where(c => c.pkMedicoID == idmedico).FirstOrDefault();
            return View(oMedico);
        }


        [HttpPost]
        public ActionResult Eliminar(string pkMedicoID)
        {

            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Eliminar", oconexion);
                cmd.Parameters.AddWithValue("pkMedicoID", pkMedicoID);

                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Medico");
        }


        [HttpGet]
        public ActionResult Eliminar2(int? idmedico)
        {
            if (idmedico == null)
                return RedirectToAction("Index", "Medico");


            Medico oMedico = oLista.Where(c => c.pkMedicoID == idmedico).FirstOrDefault();
            return View(oMedico);
        }


        [HttpPost]
        public ActionResult Eliminar2(string pkMedicoID)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Eliminar", oconexion);
                cmd.Parameters.AddWithValue("pkMedicoID", pkMedicoID);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Medico");
        }





        [HttpGet]
        public ActionResult Registrar2()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar2(Medico oMedico)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_Registrar", oConexion);

                cmd.Parameters.AddWithValue("Nombre", oMedico.Nombre);
                cmd.Parameters.AddWithValue("ApellidoPaterno", oMedico.ApellidoPaterno);
                cmd.Parameters.AddWithValue("ApellidoMaterno", oMedico.ApellidoMaterno);
                cmd.Parameters.AddWithValue("CedulaProfesional", oMedico.CedulaProfesional);
                cmd.Parameters.AddWithValue("fkEspecialidadID", oMedico.fkEspecialidadID);
                cmd.Parameters.AddWithValue("FechaNacimiento", oMedico.FechaNacimiento);
                cmd.Parameters.AddWithValue("CrBy", oMedico.CrBy);
                cmd.Parameters.AddWithValue("CrDt", DateTime.Now);

                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Medico");
        }



        [HttpGet]
        public ActionResult Editar2(int? idmedico)
        {
            if (idmedico == null)
                return RedirectToAction("Index", "Medico");

            Medico oMedico = oLista.Where(c => c.pkMedicoID == idmedico).FirstOrDefault();
            return View(oMedico);
        }


        [HttpPost]
        public ActionResult Editar2(Medico oMedico)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Editar", oConexion);
                cmd.Parameters.AddWithValue("pkMedicoID", oMedico.pkMedicoID);
                cmd.Parameters.AddWithValue("Nombre", oMedico.Nombre);
                cmd.Parameters.AddWithValue("ApellidoPaterno", oMedico.ApellidoPaterno);
                cmd.Parameters.AddWithValue("ApellidoMaterno", oMedico.ApellidoMaterno);
                cmd.Parameters.AddWithValue("CedulaProfesional", oMedico.CedulaProfesional);
                cmd.Parameters.AddWithValue("fkEspecialidadID", oMedico.fkEspecialidadID);
                cmd.Parameters.AddWithValue("FechaNacimiento", oMedico.FechaNacimiento);
                cmd.Parameters.AddWithValue("CrBy", oMedico.CrBy);
                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Medico");
        }

    }
}
