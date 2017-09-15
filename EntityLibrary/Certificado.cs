// File:    Certificado.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Certificado

using System;

public class Certificado
{
   protected void Finalize()
   {
      throw new NotImplementedException();
   }
   
   public long GetIdCertificado()
   {
      throw new NotImplementedException();
   }
   
   public void SetIdCertificado(long newIdCertificado)
   {
      throw new NotImplementedException();
   }
   
   public int GetPuntos()
   {
      throw new NotImplementedException();
   }
   
   public void SetPuntos(int newPuntos)
   {
      throw new NotImplementedException();
   }
   
   public float GetDescuento()
   {
      throw new NotImplementedException();
   }
   
   public void SetDescuento(float newDescuento)
   {
      throw new NotImplementedException();
   }
   
   public int GetTope()
   {
      throw new NotImplementedException();
   }
   
   public void SetTope(int newTope)
   {
      throw new NotImplementedException();
   }
   
   public java.lang.String GetCondiciones()
   {
      throw new NotImplementedException();
   }
   
   public void SetCondiciones(java.lang.String newCondiciones)
   {
      throw new NotImplementedException();
   }
   
   public DateTime get_fechaEmision()
   {
      throw new NotImplementedException();
   }
   
   public void SetFechaEmision(DateTime newFechaEmision)
   {
      throw new NotImplementedException();
   }
   
   public Certificado()
   {
      throw new NotImplementedException();
   }
   
   public long idCertificado;
   public int puntos;
   public float descuento;
   public int tope;
   public java.lang.String condiciones;
   public DateTime fechaEmision;
   
   public System.Collections.ArrayList certificadoRubro;
   
   /// <summary>
   /// Property for collection of CertificadoRubro
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.ArrayList CertificadoRubro
   {
      get
      {
         if (certificadoRubro == null)
            certificadoRubro = new System.Collections.ArrayList();
         return certificadoRubro;
      }
      set
      {
         RemoveAllCertificadoRubro();
         if (value != null)
         {
            foreach (CertificadoRubro oCertificadoRubro in value)
               AddCertificadoRubro(oCertificadoRubro);
         }
      }
   }
   
   /// <summary>
   /// Add a new CertificadoRubro in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddCertificadoRubro(CertificadoRubro newCertificadoRubro)
   {
      if (newCertificadoRubro == null)
         return;
      if (this.certificadoRubro == null)
         this.certificadoRubro = new System.Collections.ArrayList();
      if (!this.certificadoRubro.Contains(newCertificadoRubro))
      {
         this.certificadoRubro.Add(newCertificadoRubro);
         newCertificadoRubro.Certificado = this;
      }
   }
   
   /// <summary>
   /// Remove an existing CertificadoRubro from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveCertificadoRubro(CertificadoRubro oldCertificadoRubro)
   {
      if (oldCertificadoRubro == null)
         return;
      if (this.certificadoRubro != null)
         if (this.certificadoRubro.Contains(oldCertificadoRubro))
         {
            this.certificadoRubro.Remove(oldCertificadoRubro);
            oldCertificadoRubro.Certificado = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of CertificadoRubro from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllCertificadoRubro()
   {
      if (certificadoRubro != null)
      {
         System.Collections.ArrayList tmpCertificadoRubro = new System.Collections.ArrayList();
         foreach (CertificadoRubro oldCertificadoRubro in certificadoRubro)
            tmpCertificadoRubro.Add(oldCertificadoRubro);
         certificadoRubro.Clear();
         foreach (CertificadoRubro oldCertificadoRubro in tmpCertificadoRubro)
            oldCertificadoRubro.Certificado = null;
         tmpCertificadoRubro.Clear();
      }
   }
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
               oldConsumidor.RemoveCertificado(this);
            }
            if (value != null)
            {
               this.consumidor = value;
               this.consumidor.AddCertificado(this);
            }
         }
      }
   }

}