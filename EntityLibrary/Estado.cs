// File:    Estado.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Estado

using System;

public class Estado
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdEstado()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdEstado(long newIdEstado)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetEstado()
   {
      throw new NotImplementedException();
   }
   
   public void SetEstado(java.lang.String newEstado)
   {
      throw new NotImplementedException();
   }
   
   public Estado()
   {
      throw new NotImplementedException();
   }
   
   public long idEstado;
   public java.lang.String estado;
   
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
         newProducto.Estado = this;
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
            oldProducto.Estado = null;
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
            oldProducto.Estado = null;
         tmpProducto.Clear();
      }
   }

}