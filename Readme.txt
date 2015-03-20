
Tools used in the solution:
---------------------------
Entity Framework
 * As a database framework, this solution uses code first technology.

CommandLine Parser Library
 * For parsing input arguments for the CLI part of the solution.

StructureMap
 * Dependency Injection tool for inversion control, used by repository pattern.

Stopwatch
 * Used for timings and diagnostics of the CLI part of the solution.


Design patterns used in the solution:
-------------------------------------
Repository pattern
 * Used to sperate uses of services from implementation, in order to lower coupling of the solution.

Singleton
 * Some classes can only have one instance, in order to prevent more memory usage and higher control of the Dependency Injection.
