using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyDescription("Class library that contains the domain layer types.")]
[assembly: Guid("2BE622C6-98A4-48CE-A3FB-3D8275C6577F")]

// Remove the "AllInternalsVisible = true" property and it will generated the fakes and you can run the tests

[assembly: InternalsVisibleTo("FakesDemoTests", AllInternalsVisible = true)]
[assembly: InternalsVisibleTo("FakesDemo.Fakes", AllInternalsVisible = true)]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2", AllInternalsVisible = true)]