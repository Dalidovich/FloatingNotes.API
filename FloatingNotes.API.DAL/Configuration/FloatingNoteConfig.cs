using FloatingNotes.API.DAL.Configuration.DataType;
using FloatingNotes.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FloatingNotes.API.DAL.Configuration
{
    public class FloatingNoteConfig : IEntityTypeConfiguration<FloatingNote>
    {
        public const string Table_name = "floating_notes";

        public void Configure(EntityTypeBuilder<FloatingNote> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => new { e.Id });
            builder.HasIndex(e => e.Title);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_floating_note_id");

            builder.Property(e => e.Content)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .IsRequired()
                   .HasColumnName("content");

            builder.Property(e => e.Title)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("title");

            builder.Property(e => e.AITitle)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("ai_title");

            builder.Property(e => e.AIContent)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("ai_content");

            builder.Property(e => e.Number)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("number");

            builder.Property(e => e.Type)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("type");

            builder.Property(e => e.CreateDate)
                   .HasColumnName("create_date");

            builder.Property(e => e.Status)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("status");

            builder.Property(e => e.IsIncludedInResponseProcessing)
                   .HasColumnType(EntityDataTypes.Boolean)
                  .HasColumnName("is_included_in_response_processing");

        }
    }
}
