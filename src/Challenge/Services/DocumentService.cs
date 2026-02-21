using Challenge.Models;

namespace Challenge.Services;

internal class DocumentService
{
    private Dictionary<string, DocumentTemplate> _templates = [];

    public DocumentService()
    {
        InitializeTemplates();
    }

    private void InitializeTemplates()
    {
        InitServiceContractPrototype();

        InitConsultingContractPrototype();
    }

    private void InitServiceContractPrototype()
    {
        Console.WriteLine("Criando template de Contrato de Serviço do zero...");

        // Simulando processo custoso de inicialização
        System.Threading.Thread.Sleep(100);

        var template = new DocumentTemplate
        {
            Title = "Contrato de Prestação de Serviços",
            Category = "Contratos",
            Style = new DocumentStyle
            {
                FontFamily = "Arial",
                FontSize = 12,
                HeaderColor = "#003366",
                LogoUrl = "https://company.com/logo.png",
                PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
            },
            Workflow = new ApprovalWorkflow
            {
                RequiredApprovals = 2,
                TimeoutDays = 5
            }
        };

        template.Workflow.Approvers.Add("gerente@empresa.com");
        template.Workflow.Approvers.Add("juridico@empresa.com");

        template.Sections.Add(new Section
        {
            Name = "Cláusula 1 - Objeto",
            Content = "O presente contrato tem por objeto...",
            IsEditable = true
        });
        template.Sections.Add(new Section
        {
            Name = "Cláusula 2 - Prazo",
            Content = "O prazo de vigência será de...",
            IsEditable = true
        });
        template.Sections.Add(new Section
        {
            Name = "Cláusula 3 - Valor",
            Content = "O valor total do contrato é de...",
            IsEditable = true
        });

        template.RequiredFields.Add("NomeCliente");
        template.RequiredFields.Add("CPF");
        template.RequiredFields.Add("Endereco");

        template.Tags.Add("contrato");
        template.Tags.Add("servicos");

        template.Metadata["Versao"] = "1.0";
        template.Metadata["Departamento"] = "Comercial";
        template.Metadata["UltimaRevisao"] = DateTime.Now.ToString();

        _templates["SERVICE_CONTRACT"] = template;
    }

    private void InitConsultingContractPrototype()
    {
        Console.WriteLine("Criando template de Contrato de Consultoria do zero...");

        System.Threading.Thread.Sleep(100);

        var template = new DocumentTemplate
        {
            Title = "Contrato de Consultoria",
            Category = "Contratos",
            Style = new DocumentStyle
            {
                FontFamily = "Arial",
                FontSize = 12,
                HeaderColor = "#003366",
                LogoUrl = "https://company.com/logo.png",
                PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
            },
            Workflow = new ApprovalWorkflow
            {
                RequiredApprovals = 2,
                TimeoutDays = 5
            }
        };

        template.Workflow.Approvers.Add("gerente@empresa.com");
        template.Workflow.Approvers.Add("juridico@empresa.com");

        template.Sections.Add(new Section
        {
            Name = "Cláusula 1 - Objeto",
            Content = "O presente contrato de consultoria tem por objeto...",
            IsEditable = true
        });
        template.Sections.Add(new Section
        {
            Name = "Cláusula 2 - Prazo",
            Content = "O prazo de vigência será de...",
            IsEditable = true
        });

        template.RequiredFields.Add("NomeCliente");
        template.RequiredFields.Add("CPF");
        template.RequiredFields.Add("Endereco");

        template.Tags.Add("contrato");
        template.Tags.Add("consultoria");

        template.Metadata["Versao"] = "1.0";
        template.Metadata["Departamento"] = "Comercial";

        _templates["CONSULTING_CONTRACT"] = template;
    }

    public DocumentTemplate CreateServiceContract()
    {
        return (DocumentTemplate)_templates["SERVICE_CONTRACT"].DeepClone();
    }

    public DocumentTemplate CreateConsultingContract()
    {
        return (DocumentTemplate)_templates["CONSULTING_CONTRACT"].DeepClone();
    }
    public static void DisplayTemplate(DocumentTemplate template)
    {
        Console.WriteLine($"\n=== {template.Title} ===");
        Console.WriteLine($"Categoria: {template.Category}");
        Console.WriteLine($"Seções: {template.Sections.Count}");
        Console.WriteLine($"Campos obrigatórios: {string.Join(", ", template.RequiredFields)}");
        Console.WriteLine($"Aprovadores: {string.Join(", ", template.Workflow.Approvers)}");
    }
}
