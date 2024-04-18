﻿using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesDominio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Filtros;

namespace Obligatorio.Controllers
{
    public class UsuarioController : Controller
    {

        public ICUAlta<Usuario> CUAltaUsuario { get; set; }
        public ICUBaja CUBajaUsuario { get; set; }
        public ICUModificar<Usuario> CUModificarUsuario { get; set; }
        public ICUListado<Usuario> CUListadoUsuario { get; set; }
        public ICUBuscarPorId<Usuario> CUBuscarUsuario { get; set; }


        public UsuarioController(ICUAlta<Usuario> cuAltaUsuario, ICUBaja cuBajaUsuario, ICUModificar<Usuario> cuModificarUsuario, ICUListado<Usuario> cUListadoUsuario, ICUBuscarPorId<Usuario> cUBuscarUsuario)
        {
            CUAltaUsuario = cuAltaUsuario;
            CUBajaUsuario = cuBajaUsuario;
            CUModificarUsuario = cuModificarUsuario;
            CUListadoUsuario = cUListadoUsuario;
            CUBuscarUsuario = cUBuscarUsuario;
        }

        // GET: UsuarioController
        [User]
        public ActionResult Index()
        {
            List<Usuario> usuarios = CUListadoUsuario.ObtenerListado();
            return View(usuarios);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario user = CUBuscarUsuario.Buscar(id);
            return View(user);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario user)
        {
            try
            {
                user.id = id;
                CUModificarUsuario.Modificar(user);
                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;

            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error, no se pudo realizar la modificación";
            }

            return View();
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
