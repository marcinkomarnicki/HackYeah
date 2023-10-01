﻿using HackYeah.Application.Enums;

namespace HackYeah.Application.Queries.Models;

public class GetEncounterTypesResult
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public bool IsWild { get; set; }
    public List<GetEncounterTypesResultProperties> Properties { get; set; }
}

public class GetEncounterTypesResultProperties
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ValueType { get; set; }
}