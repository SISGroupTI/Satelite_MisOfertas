// File:    DetalleOferta.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class DetalleOferta

using System;

public class DetalleOferta
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdDetalle()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdDetalle(long newIdDetalle)
   {
      throw new NotImplementedException();
   }
   
   public int GetCantidadMinima()
   {
      throw new NotImplementedException();
   }
   
   public void SetCantidadMinima(int newCantidadMinima)
   {
      throw new NotImplementedException();
   }
   
   public int GetCantidadMaxima()
   {
      throw new NotImplementedException();
   }
   
   public void SetCantidadMaxima(int newCantidadMaxima)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaIngreso()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaIngreso(DateTime newFechaIngreso)
   {
      throw new NotImplementedException();
   }
   
   public DetalleOferta()
   {
      throw new NotImplementedException();
   }
   
   public long idDetalle;
   public int cantidadMinima;
   public int cantidadMaxima;
   public DateTime fechaIngreso;
   
   public Oferta oferta;
   
   /// <summary>
   /// Property for Oferta
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Oferta Oferta
   {
      get
      {
         return oferta;
      }
      set
      {
         if (this.oferta == null || !this.oferta.Equals(value))
         {
            if (this.oferta != null)
            {
               Oferta oldOferta = this.oferta;
               this.oferta = null;
               oldOferta.RemoveDetalleOferta(this);
            }
            if (value != null)
            {
               this.oferta = value;
               this.oferta.AddDetalleOferta(this);
            }
         }
      }
   }
   public Producto producto;
   
   /// <summary>
   /// Property for Producto
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Producto Producto
   {
      get
      {
         return producto;
      }
      set
      {
         if (this.producto == null || !this.producto.Equals(value))
         {
            if (this.producto != null)
            {
               Producto oldProducto = this.producto;
               this.producto = null;
               oldProducto.RemoveDetalleOferta(this);
            }
            if (value != null)
            {
               this.producto = value;
               this.producto.AddDetalleOferta(this);
            }
         }
      }
   }

}