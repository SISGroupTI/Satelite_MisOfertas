// File:    Escala.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Escala

using System;

public class Escala
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdEscala()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdEscala(long newIdEscala)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetNota()
   {
      throw new NotImplementedException();
   }
   
   public void SetNota(java.lang.String newNota)
   {
      throw new NotImplementedException();
   }
   
   public Escala()
   {
      throw new NotImplementedException();
   }
   
   public long idEscala;
   public java.lang.String nota;
   
   public System.Collections.ArrayList valoracion;
   
   /// <summary>
   /// Property for collection of Valoracion
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList Valoracion
   {
      get
      {
         if (valoracion == null)
            valoracion = new System.Collections.ArrayList();
         return valoracion;
      }
      set
      {
         RemoveAllValoracion();
         if (value != null)
         {
            foreach (Valoracion oValoracion in value)
               AddValoracion(oValoracion);
         }
      }
   }
   
   /// <summary>
   /// Add a new Valoracion in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddValoracion(Valoracion newValoracion)
   {
      if (newValoracion == null)
         return;
      if (this.valoracion == null)
         this.valoracion = new System.Collections.ArrayList();
      if (!this.valoracion.Contains(newValoracion))
      {
         this.valoracion.Add(newValoracion);
         newValoracion.Escala = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Valoracion from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveValoracion(Valoracion oldValoracion)
   {
      if (oldValoracion == null)
         return;
      if (this.valoracion != null)
         if (this.valoracion.Contains(oldValoracion))
         {
            this.valoracion.Remove(oldValoracion);
            oldValoracion.Escala = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Valoracion from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllValoracion()
   {
      if (valoracion != null)
      {
         System.Collections.ArrayList tmpValoracion = new System.Collections.ArrayList();
         foreach (Valoracion oldValoracion in valoracion)
            tmpValoracion.Add(oldValoracion);
         valoracion.Clear();
         foreach (Valoracion oldValoracion in tmpValoracion)
            oldValoracion.Escala = null;
         tmpValoracion.Clear();
      }
   }

}