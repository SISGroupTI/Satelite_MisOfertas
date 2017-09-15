// File:    Permiso.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Permiso

using System;
using System.Collections.Generic;

public class Permiso
{
    private long idPermiso;
    private Perfil perfil;
    private List<Modulo> modulo;

    public long IdPermiso { get => idPermiso; set => idPermiso = value; }
    public Perfil Perfil { get => perfil; set => perfil = value; }
    public List<Modulo> Modulo { get => modulo; set => modulo = value; }

    public Permiso(long idPermiso, Perfil perfil, List<Modulo> modulo)
    {
        this.idPermiso = idPermiso;
        this.perfil = perfil;
        this.modulo = modulo;
    }

    public Permiso()
    {
    }
}