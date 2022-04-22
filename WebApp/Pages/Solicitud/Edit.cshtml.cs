using Entity.dbo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBL;
namespace WebApp.Pages.Solicitud
{
    public class EditModel : PageModel
    
    {
        private readonly ISolicitudService _solicitud;
        private readonly IClienteService _cliente;
        private readonly IServicioService _servicio;

        public string Mensaje { get; set; } = "";

        public IEnumerable<ClienteEntity> ListCliente { get; set; } = new List<ClienteEntity>();
        public IEnumerable<ServicioEntity> ListServicio { get; set; } = new List<ServicioEntity>();

        public EditModel(ISolicitudService solicitud, IClienteService cliente, IServicioService servicio)
        {
            this._solicitud = solicitud;
            this._cliente = cliente;
            this._servicio = servicio;

        }


        public async Task<IActionResult> OnGet()
        {

            try
            {
                ListCliente = await _cliente.GET();
                ListServicio = await _servicio.GET();


                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnPost(SolicitudEntity entity)
        {

            try
            {
                var result = await _solicitud.Create(entity);

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);

                }

                TempData["Msg"] = "El registro fue agregado correctamente";

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);

            }
        }
    }
}
