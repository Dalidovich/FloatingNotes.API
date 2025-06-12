using FloatingNotes.API.DAL.Configuration.DataType;
using FloatingNotes.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FloatingNotes.API.DAL.Configuration
{
    public class ConnectionFloatingNoteConfig : IEntityTypeConfiguration<ConnectionFloatingNote>
    {
        public const string Table_name = "connected_floating_notes";

        public void Configure(EntityTypeBuilder<ConnectionFloatingNote> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(x => new { x.MasterFloatingNoteId, x.ConnectedFloatingNoteId });

            builder.Property(e => e.MasterFloatingNoteId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("master_floating_note_id");

            builder.Property(e => e.ConnectedFloatingNoteId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("connected_floating_note_id");

            builder.HasOne(x => x.MasterFloatingNote)
                   .WithMany(fn => fn.ConnectedFloatingNotes)
                   .HasForeignKey(x => x.MasterFloatingNoteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ConnectedFloatingNote)
                   .WithMany()
                   .HasForeignKey(x => x.ConnectedFloatingNoteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
