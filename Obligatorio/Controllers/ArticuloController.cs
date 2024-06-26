﻿using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.ExcepcionesDominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class ArticuloController : Controller
    {

        public ICUAlta<DTOArticulo> CUAltaArticulo { get; set; }
        public ICUListado<DTOArticulo> CUListadoArticulo{ get; set; }

        public ArticuloController(ICUAlta<DTOArticulo> cUAltaArticulo, ICUListado<DTOArticulo> cUListadoArticulo)
        {
            CUAltaArticulo = cUAltaArticulo;
            CUListadoArticulo = cUListadoArticulo;
        }


        // GET: ArticuloController
        public ActionResult Index()
        {
            List<DTOArticulo> clientes = CUListadoArticulo.ObtenerListado();
            return View(clientes);
        }

        // GET: ArticuloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOArticulo nuevo)
        {
            try
            {
                    CUAltaArticulo.Alta(nuevo);
                    return RedirectToAction(nameof(Index));             
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta del Articulo";
            }

            return View(nuevo);
        }

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticuloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticuloController/Delete/5
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
