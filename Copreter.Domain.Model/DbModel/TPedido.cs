﻿using System;
using System.Collections.Generic;

namespace Copreter.Domain.Model.DbModel
{
    public partial class TPedido
    {
        public TPedido()
        {
            TAdenda = new HashSet<TAdenda>();
            TIncidencia = new HashSet<TIncidencia>();
            TPedidoOrdenServicio = new HashSet<TPedidoOrdenServicio>();
            TPedidoSolicitud = new HashSet<TPedidoSolicitud>();
        }

        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Obra { get; set; } = null!;
        public string Empresa { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public int IdEstadoPedido { get; set; }
        public int IdUsuario { get; set; }
        public int? IdTrabajador { get; set; }
        public int? IdUnidad { get; set; }
        public int Cantidad { get; set; }
        public bool Borrado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TEstadoPedido IdEstadoPedidoNavigation { get; set; } = null!;
        public virtual TTrabajador? IdTrabajadorNavigation { get; set; }
        public virtual TUnidad? IdUnidadNavigation { get; set; }
        public virtual TUsuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<TAdenda> TAdenda { get; set; }
        public virtual ICollection<TIncidencia> TIncidencia { get; set; }
        public virtual ICollection<TPedidoOrdenServicio> TPedidoOrdenServicio { get; set; }
        public virtual ICollection<TPedidoSolicitud> TPedidoSolicitud { get; set; }
    }
}
