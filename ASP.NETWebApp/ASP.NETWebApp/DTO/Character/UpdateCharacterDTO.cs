﻿namespace ASP.NETWebApp.DTO.Character
{
    public class UpdateCharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
    }
}
