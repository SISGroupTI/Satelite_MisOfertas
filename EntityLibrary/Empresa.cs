// File:    Empresa.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Empresa

using System;

public class Empresa
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdEmpresa()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdEmpresa(long newIdEmpresa)
   {
      throw new NotImplementedException();
   }
   
   public int GetRutEmpresa()
   {
      throw new NotImplementedException();
   }
   
   public void SetRutEmpresa(int newRutEmpresa)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetDvEmpresa()
   {
      throw new NotImplementedException();
   }
   
   public void SetDvEmpresa(java.lang.String newDvEmpresa)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetNombreEmpresa()
   {
      throw new NotImplementedException();
   }
   
   public void SetNombreEmpresa(java.lang.String newNombreEmpresa)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaIncorporacion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaIncorporacion(DateTime newFechaIncorporacion)
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
   
   public short GetIsActivo()
   {
      throw new NotImplementedException();
   }
   
   public void SetIsActivo(short newIsActivo)
   {
      throw new NotImplementedException();
   }
   
   public Empresa()
   {
      throw new NotImplementedException();
   }
   
   public long idEmpresa;
   public int rutEmpresa;
   public java.lang.String dvEmpresa;
   public java.lang.String nombreEmpresa;
   public DateTime fechaIncorporacion;
   public DateTime fechaModificacion;
   public DateTime fechaEliminacion;
   public short isActivo;
   
   public System.Collections.ArrayList local;
   
   /// <summary>
   /// Property for collection of Local
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Local
   {
      get
      {
         if (local == null)
            local = new System.Collections.ArrayList();
         return local;
      }
      set
      {
         RemoveAllLocal();
         if (value != null)
         {
            foreach (Local oLocal in value)
               AddLocal(oLocal);
         }
      }
   }
   
   /// <summary>
   /// Add a new Local in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddLocal(Local newLocal)
   {
      if (newLocal == null)
         return;
      if (this.local == null)
         this.local = new System.Collections.ArrayList();
      if (!this.local.Contains(newLocal))
      {
         this.local.Add(newLocal);
         newLocal.Empresa = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Local from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveLocal(Local oldLocal)
   {
      if (oldLocal == null)
         return;
      if (this.local != null)
         if (this.local.Contains(oldLocal))
         {
            this.local.Remove(oldLocal);
            oldLocal.Empresa = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Local from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllLocal()
   {
      if (local != null)
      {
         System.Collections.ArrayList tmpLocal = new System.Collections.ArrayList();
         foreach (Local oldLocal in local)
            tmpLocal.Add(oldLocal);
         local.Clear();
         foreach (Local oldLocal in tmpLocal)
            oldLocal.Empresa = null;
         tmpLocal.Clear();
      }
   }

}