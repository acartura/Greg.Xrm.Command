﻿namespace Greg.Xrm.Command.Commands.Table
{
    [Command("table", "delete", HelpText = "Deletes a table (if possible) from the current Dataverse environment")]
    public class DeleteCommand
    {
        [Option("name", "n", IsRequired = true, HelpText = "The schema name of the table to delete")]
        public string? SchemaName { get; set; }
    }
}
