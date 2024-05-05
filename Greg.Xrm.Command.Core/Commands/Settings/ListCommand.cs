﻿
using System.ComponentModel.DataAnnotations;

namespace Greg.Xrm.Command.Commands.Settings
{
	[Command("settings", "list", HelpText = "List settings defined for the current environment")]
	public class ListCommand : IValidatableObject
	{
		[Option("origin", "o", "Indicates if the list of settings to retrieve is the whole list of settings, or just the settings in the specified solution.", DefaultValue = Origin.Solution)]
		public Origin Origin { get; set; } = Origin.Solution;

		[Option("filter", "f", "Indicates if the list of settings to retrieve should include all settings, or only visible settings.", DefaultValue = Which.Visible)]
		public Which Filter { get; set; } = Which.Visible;


		[Option("format", "fmt", "The format of the output. Default is Text. Use Json to get the output in JSON format.")]
		public Format Format { get; set; } = Format.Text;


		[Option("output", "out", "If the format specified is Json or Excel, this is the name of the file where the output will be saved. For Excel files is mandatory. For JSON, if not specified, the output will be written only to the console.")]
		public string? OutputFileName { get; set; }

		[Option("run", "r", HelpText = "Allows to specify whether the output file should be automatically opened or not.", DefaultValue = false)]
		public bool AutoRun { get; set; } = false;


		[Option("solution", "s", HelpText = "The solution to get the settings from. If not specified, the default solution is considered.")]
		public string? SolutionName { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Format == Format.Excel && string.IsNullOrWhiteSpace(OutputFileName))
			{
				yield return new ValidationResult("When the format is Excel, the output file name must be specified.", new[] { nameof(OutputFileName) });
			}
		}
	}


	public enum Origin
	{
		Solution,
		All
	}

	public enum Which
	{
		Visible,
		All
	}

	public enum Format
	{
		Text,
		Json,
		Excel
	}
}
