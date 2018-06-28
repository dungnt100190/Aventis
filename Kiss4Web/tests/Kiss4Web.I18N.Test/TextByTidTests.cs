using System;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.I18N;
using Kiss4Web.Infrastructure.Modularity;
using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure.TestServer;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Kiss4Web.I18N.Test
{
    public class TextByTidTests : IntegrationTest
    {
        public TextByTidTests(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task GetExistingText()
        {
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var translations = IntegrationTestEnvironment.Container.GetInstance<IKiss4TranslationProvider>();
                var text = await translations.GetText(3, LanguageCode.Deutsch);
                text.ShouldBe("Anzahl Personen: {0}");
            }
        }

        [Fact]
        public async Task GetTextDe()
        {
            // Arrange
            using (var dataManager = IntegrationTestEnvironment.CreateTestDataManager())
            {
                var expectedText = Guid.NewGuid().ToString();
                var textDe = await dataManager.Insert(new XLangText
                {
                    LanguageCode = LanguageCode.Deutsch,
                    Text = expectedText
                });
                using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
                {
                    // Act
                    var translations = IntegrationTestEnvironment.Container.GetInstance<IKiss4TranslationProvider>();
                    var text = await translations.GetText(textDe.Tid, textDe.LanguageCode);

                    // Assert
                    text.ShouldBe(expectedText);
                }
            }
        }

        [Fact]
        public async Task GetTextDe_cached()
        {
            // Arrange
            var dataManager = IntegrationTestEnvironment.CreateTestDataManager();
            var expectedText = Guid.NewGuid().ToString();
            var textDe = await dataManager.Insert(new XLangText
            {
                LanguageCode = LanguageCode.Deutsch,
                Text = expectedText
            });

            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                // Act
                var translations = IntegrationTestEnvironment.Container.GetInstance<IKiss4TranslationProvider>();
                var text = await translations.GetText(textDe.Tid, textDe.LanguageCode);
                text.ShouldBe(expectedText);

                // remove text from db
                await dataManager.Cleanup();

                // check if test is still in the cache
                var cachedText = await translations.GetText(textDe.Tid, textDe.LanguageCode);

                // Assert
                cachedText.ShouldBe(expectedText);
            }

            // check if the text is really gone in the database
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var text = await IntegrationTestEnvironment.Container.GetInstance<IQueryable<XLangText>>()
                                                                     .FirstOrDefaultAsync(txt => txt.Tid == textDe.Tid);
                text.ShouldBeNull();
            }
        }
    }
}