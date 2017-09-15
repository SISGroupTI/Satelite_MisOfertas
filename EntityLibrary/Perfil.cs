// File:    Perfil.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Perfil

using System;
using System.Collections;

public class Perfil
{
    private long idPerfil;
    private String nombrePerfil;

    public long IdPerfil { get => idPerfil; set => idPerfil = value; }
    public string NombrePerfil { get => nombrePerfil; set => nombrePerfil = value; }

    public Perfil(long idPerfil, string nombrePerfil)
    {
        this.idPerfil = idPerfil;
        this.nombrePerfil = nombrePerfil;
    }

    public Perfil()
    {
    }
}