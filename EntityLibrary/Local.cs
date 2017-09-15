// File:    Local.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Local

using System;

public class Local
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdLocal()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdLocal(long newIdLocal)
   {
      throw new NotImplementedException();
   }
   
   public int GetNumeroLocal()
   {
      throw new NotImplementedException();
   }
   
   public void SetNumeroLocal(int newNumeroLocal)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetDireccion()
   {
      throw new NotImplementedException();
   }
   
   public void SetDireccion(java.lang.String newDireccion)
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
   
   public DateTime get_fechaEliminacion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaEliminacion(DateTime newFechaEliminacion)
   {
      throw new NotImplementedException();
   }
   
   public Local()
   {
      throw new NotImplementedException();
   }
   
   public long idLocal;
   public int numeroLocal;
   public java.lang.String direccion;
   public DateTime fechaRegistro;
   public DateTime fechaEliminacion;
   
   public System.Collections.ArrayList trabajador;
   
   /// <summary>
   /// Property for collection of Trabajador
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Trabajador
   {
      get
      {
         if (trabajador == null)
            trabajador = new System.Collections.ArrayList();
         return trabajador;
      }
      set
      {
         RemoveAllTrabajador();
         if (value != null)
         {
            foreach (Trabajador oTrabajador in value)
               AddTrabajador(oTrabajador);
         }
      }
   }
   
   /// <summary>
   /// Add a new Trabajador in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddTrabajador(Trabajador newTrabajador)
   {
      if (newTrabajador == null)
         return;
      if (this.trabajador == null)
         this.trabajador = new System.Collections.ArrayList();
      if (!this.trabajador.Contains(newTrabajador))
      {
         this.trabajador.Add(newTrabajador);
         newTrabajador.Local = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Trabajador from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveTrabajador(Trabajador oldTrabajador)
   {
      if (oldTrabajador == null)
         return;
      if (this.trabajador != null)
         if (this.trabajador.Contains(oldTrabajador))
         {
            this.trabajador.Remove(oldTrabajador);
            oldTrabajador.Local = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Trabajador from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllTrabajador()
   {
      if (trabajador != null)
      {
         System.Collections.ArrayList tmpTrabajador = new System.Collections.ArrayList();
         foreach (Trabajador oldTrabajador in trabajador)
            tmpTrabajador.Add(oldTrabajador);
         trabajador.Clear();
         foreach (Trabajador oldTrabajador in tmpTrabajador)
            oldTrabajador.Local = null;
         tmpTrabajador.Clear();
      }
   }
   public System.Collections.ArrayList oferta;
   
   /// <summary>
   /// Property for collection of Oferta
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Oferta
   {
      get
      {
         if (oferta == null)
            oferta = new System.Collections.ArrayList();
         return oferta;
      }
      set
      {
         RemoveAllOferta();
         if (value != null)
         {
            foreach (Oferta oOferta in value)
               AddOferta(oOferta);
         }
      }
   }
   
   /// <summary>
   /// Add a new Oferta in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddOferta(Oferta newOferta)
   {
      if (newOferta == null)
         return;
      if (this.oferta == null)
         this.oferta = new System.Collections.ArrayList();
      if (!this.oferta.Contains(newOferta))
      {
         this.oferta.Add(newOferta);
         newOferta.Local = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Oferta from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveOferta(Oferta oldOferta)
   {
      if (oldOferta == null)
         return;
      if (this.oferta != null)
         if (this.oferta.Contains(oldOferta))
         {
            this.oferta.Remove(oldOferta);
            oldOferta.Local = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Oferta from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllOferta()
   {
      if (oferta != null)
      {
         System.Collections.ArrayList tmpOferta = new System.Collections.ArrayList();
         foreach (Oferta oldOferta in oferta)
            tmpOferta.Add(oldOferta);
         oferta.Clear();
         foreach (Oferta oldOferta in tmpOferta)
            oldOferta.Local = null;
         tmpOferta.Clear();
      }
   }
   public System.Collections.ArrayList producto;
   
   /// <summary>
   /// Property for collection of Producto
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Producto
   {
      get
      {
         if (producto == null)
            producto = new System.Collections.ArrayList();
         return producto;
      }
      set
      {
         RemoveAllProducto();
         if (value != null)
         {
            foreach (Producto oProducto in value)
               AddProducto(oProducto);
         }
      }
   }
   
   /// <summary>
   /// Add a new Producto in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddProducto(Producto newProducto)
   {
      if (newProducto == null)
         return;
      if (this.producto == null)
         this.producto = new System.Collections.ArrayList();
      if (!this.producto.Contains(newProducto))
      {
         this.producto.Add(newProducto);
         newProducto.Local = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Producto from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveProducto(Producto oldProducto)
   {
      if (oldProducto == null)
         return;
      if (this.producto != null)
         if (this.producto.Contains(oldProducto))
         {
            this.producto.Remove(oldProducto);
            oldProducto.Local = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Producto from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllProducto()
   {
      if (producto != null)
      {
         System.Collections.ArrayList tmpProducto = new System.Collections.ArrayList();
         foreach (Producto oldProducto in producto)
            tmpProducto.Add(oldProducto);
         producto.Clear();
         foreach (Producto oldProducto in tmpProducto)
            oldProducto.Local = null;
         tmpProducto.Clear();
      }
   }
   public Empresa empresa;
   
   /// <summary>
   /// Property for Empresa
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Empresa Empresa
   {
      get
      {
         return empresa;
      }
      set
      {
         if (this.empresa == null || !this.empresa.Equals(value))
         {
            if (this.empresa != null)
            {
               Empresa oldEmpresa = this.empresa;
               this.empresa = null;
               oldEmpresa.RemoveLocal(this);
            }
            if (value != null)
            {
               this.empresa = value;
               this.empresa.AddLocal(this);
            }
         }
      }
   }

}