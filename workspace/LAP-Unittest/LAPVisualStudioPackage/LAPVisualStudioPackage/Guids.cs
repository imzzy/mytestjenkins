// Guids.cs
// MUST match guids.h
using System;

namespace LAPInc.LAPVisualStudioPackage
{
    static class GuidList
    {
        public const string guidLAPVisualStudioPackagePkgString = "f34320ce-fae4-4ba6-98b4-1a82226c19ef";
        public const string guidLAPVisualStudioPackageCmdSetString = "dedeee2c-0696-4abd-9a8f-eb82e82db17d";

        public static readonly Guid guidLAPVisualStudioPackageCmdSet = new Guid(guidLAPVisualStudioPackageCmdSetString);
    };
}