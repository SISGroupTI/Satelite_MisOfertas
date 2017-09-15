// File:    Valoracion.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Valoracion

using System;

public class Valoracion
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdValoracion()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdValoracion(long newIdValoracion)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetFotoValoracion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFotoValoracion(java.lang.String newFotoValoracion)
   {
      throw new NotImplementedException();
   }
   
   public int GetPuntoGanado()
   {
      throw new NotImplementedException();
   }
   
   public void SetPuntoGanado(int newPuntoGanado)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaValoracion()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaValoracion(DateTime newFechaValoracion)
   {
      throw new NotImplementedException();
   }
   
   public Valoracion()
   {
      throw new NotImplementedException();
   }
   
   public long idValoracion;
   public java.lang.String fotoValoracion;
   public int puntoGanado;
   public DateTime fechaValoracion;
   
   public Consumidor consumidor;
   
   /// <summary>
   /// Property for Consumidor
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Consumidor Consumidor
   {
      get
      {
         return consumidor;
      }
      set
      {
         if (this.consumidor == null || !this.consumidor.Equals(value))
         {
            if (this.consumidor != null)
            {
               Consumidor oldConsumidor = this.consumidor;
               this.consumidor = null;
               oldConsumidor.RemoveValoracion(this);
            }
            if (value != null)
            {
               this.consumidor = value;
               this.consumidor.AddValoracion(this);
            }
         }
      }
   }
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
               oldOferta.RemoveValoracion(this);
            }
            if (value != null)
            {
               this.oferta = value;
               this.oferta.AddValoracion(this);
            }
         }
      }
   }
   public Escala escala;
   
   /// <summary>
   /// Property for Escala
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Escala Escala
   {
      get
      {
         return escala;
      }
      set
      {
         if (this.escala == null || !this.escala.Equals(value))
         {
            if (this.escala != null)
            {
               Escala oldEscala = this.escala;
               this.escala = null;
               oldEscala.RemoveValoracion(this);
            }
            if (value != null)
            {
               this.escala = value;
               this.escala.AddValoracion(this);
            }
         }
      }
   }

}