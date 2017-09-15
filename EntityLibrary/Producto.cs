// File:    Producto.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Producto

using System;

public class Producto
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdProducto()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdProducto(long newIdProducto)
   {
      throw new NotImplementedException();
   }
   
   public int GetCodigoProducto()
   {
      throw new NotImplementedException();
   }
   
   public void SetCodigoProducto(int newCodigoProducto)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetDescripcion()
   {
      throw new NotImplementedException();
   }
   
   public void SetDescripcion(java.lang.String newDescripcion)
   {
      throw new NotImplementedException();
   }
   
   public int GetPrecioNormal()
   {
      throw new NotImplementedException();
   }
   
   public void SetPrecioNormal(int newPrecioNormal)
   {
      throw new NotImplementedException();
   }
   
   public int GetPrecioOferta()
   {
      throw new NotImplementedException();
   }
   
   public void SetPrecioOferta(int newPrecioOferta)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaCaducidad()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaCaducidad(DateTime newFechaCaducidad)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaRegistro()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaRegistro(DateTime newFechaRegistro)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaModificacion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaModificacion(DateTime newFechaModificacion)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaEliminacion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaEliminacion(DateTime newFechaEliminacion)
   {
      throw new NotImplementedException();
   }
   
   public Producto()
   {
      throw new NotImplementedException();
   }
   
   public long idProducto;
   public int codigoProducto;
   public java.lang.String descripcion;
   public int precioNormal;
   public int precioOferta;
   public DateTime fechaCaducidad;
   public DateTime fechaRegistro;
   public DateTime fechaModificacion;
   public DateTime fechaEliminacion;
   
   public System.Collections.ArrayList detalleOferta;
   
   /// <summary>
   /// Property for collection of DetalleOferta
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList DetalleOferta
   {
      get
      {
         if (detalleOferta == null)
            detalleOferta = new System.Collections.ArrayList();
         return detalleOferta;
      }
      set
      {
         RemoveAllDetalleOferta();
         if (value != null)
         {
            foreach (DetalleOferta oDetalleOferta in value)
               AddDetalleOferta(oDetalleOferta);
         }
      }
   }
   
   /// <summary>
   /// Add a new DetalleOferta in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddDetalleOferta(DetalleOferta newDetalleOferta)
   {
      if (newDetalleOferta == null)
         return;
      if (this.detalleOferta == null)
         this.detalleOferta = new System.Collections.ArrayList();
      if (!this.detalleOferta.Contains(newDetalleOferta))
      {
         this.detalleOferta.Add(newDetalleOferta);
         newDetalleOferta.Producto = this;
      }
   }
   
   /// <summary>
   /// Remove an existing DetalleOferta from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveDetalleOferta(DetalleOferta oldDetalleOferta)
   {
      if (oldDetalleOferta == null)
         return;
      if (this.detalleOferta != null)
         if (this.detalleOferta.Contains(oldDetalleOferta))
         {
            this.detalleOferta.Remove(oldDetalleOferta);
            oldDetalleOferta.Producto = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of DetalleOferta from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllDetalleOferta()
   {
      if (detalleOferta != null)
      {
         System.Collections.ArrayList tmpDetalleOferta = new System.Collections.ArrayList();
         foreach (DetalleOferta oldDetalleOferta in detalleOferta)
            tmpDetalleOferta.Add(oldDetalleOferta);
         detalleOferta.Clear();
         foreach (DetalleOferta oldDetalleOferta in tmpDetalleOferta)
            oldDetalleOferta.Producto = null;
         tmpDetalleOferta.Clear();
      }
   }
   public Estado estado;
   
   /// <summary>
   /// Property for Estado
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Estado Estado
   {
      get
      {
         return estado;
      }
      set
      {
         if (this.estado == null || !this.estado.Equals(value))
         {
            if (this.estado != null)
            {
               Estado oldEstado = this.estado;
               this.estado = null;
               oldEstado.RemoveProducto(this);
            }
            if (value != null)
            {
               this.estado = value;
               this.estado.AddProducto(this);
            }
         }
      }
   }
   public Local local;
   
   /// <summary>
   /// Property for Local
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Local Local
   {
      get
      {
         return local;
      }
      set
      {
         if (this.local == null || !this.local.Equals(value))
         {
            if (this.local != null)
            {
               Local oldLocal = this.local;
               this.local = null;
               oldLocal.RemoveProducto(this);
            }
            if (value != null)
            {
               this.local = value;
               this.local.AddProducto(this);
            }
         }
      }
   }

}