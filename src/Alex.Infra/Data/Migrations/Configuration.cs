using Alex.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace Alex.Infra.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<AppDBContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }
    }
}
