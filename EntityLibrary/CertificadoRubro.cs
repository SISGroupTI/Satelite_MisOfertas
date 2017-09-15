// File:    CertificadoRubro.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class CertificadoRubro

using System;

public class CertificadoRubro
{
   public Certificado certificado;
   
   /// <summary>
   /// Property for Certificado
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Certificado Certificado
   {
      get
      {
         return certificado;
      }
      set
      {
         if (this.certificado == null || !this.certificado.Equals(value))
         {
            if (this.certificado != null)
            {
               Certificado oldCertificado = this.certificado;
               this.certificado = null;
               oldCertificado.RemoveCertificadoRubro(this);
            }
            if (value != null)
            {
               this.certificado = value;
               this.certificado.AddCertificadoRubro(this);
            }
         }
      }
   }
   public Rubro rubro;
   
   /// <summary>
   /// Property for Rubro
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Rubro Rubro
   {
      get
      {
         return rubro;
      }
      set
      {
         if (this.rubro == null || !this.rubro.Equals(value))
         {
            if (this.rubro != null)
            {
               Rubro oldRubro = this.rubro;
               this.rubro = null;
               oldRubro.RemoveCertificadoRubro(this);
            }
            if (value != null)
            {
               this.rubro = value;
               this.rubro.AddCertificadoRubro(this);
            }
         }
      }
   }

}