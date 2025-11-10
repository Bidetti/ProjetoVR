## CIC904 - Multimídia e Realidade Virtual

### Projeto de Realidade Virtual - Catálogo Interativo

---

## 👥 Equipe de Desenvolvimento

| Nome | RA |
|------|-----|
| Leonardo Guilmo Chin | 22.00512-9 |
| Luigi Guimarães Trevisan | 22.01102-0 |
| Rafael Bidetti B S Ferreira | 22.01019-0 |
| Rodrigo Diana Siqueira | 22.00680-0 |
| Vitor Moretti Negresiolo | 22.01049-0 |

---

## 📋 Descrição do Projeto

Este projeto consiste em uma **loja virtual em realidade virtual** que simula um catálogo interativo de produtos Apple. O usuário pode explorar um ambiente 3D imersivo, interagir com produtos da Apple e visualizar suas especificações técnicas de forma intuitiva e envolvente.

### Conceito

O ambiente simula uma loja Apple minimalista, onde os produtos são exibidos em pedestais. Ao interagir com qualquer produto, o usuário ativa uma experiência visual única: o produto começa a flutuar e girar no ar, enquanto uma interface 2D semi-transparente é exibida no espaço 3D, mostrando informações detalhadas do produto.

---

## 🎯 Objetivos

- Criar uma experiência imersiva de catálogo de produtos em VR
- Implementar interações naturais e intuitivas com objetos 3D
- Demonstrar o potencial da realidade virtual para aplicações comerciais
- Desenvolver um sistema modular e escalável para adição de novos produtos

---

## 🛠️ Tecnologias Utilizadas

- **Engine**: Unity 2022.3+ (Unity 6)
- **Template Base**: VR Template (Unity)
- **Framework XR**: XR Interaction Toolkit
- **API de VR**: OpenXR
- **Linguagem**: C#
- **Controle de Versão**: Git

### Pacotes Unity

- `com.unity.xr.interaction.toolkit` - Sistema de interação em VR
- `com.unity.xr.openxr` - Suporte multiplataforma para dispositivos VR
- `TextMeshPro` - Renderização avançada de texto

---

## 🎮 Produtos Disponíveis

O catálogo conta com **3 produtos Apple** dispostos em pedestais:

1. **AirPods Pro 3**
   - Fones de ouvido sem fio com cancelamento ativo de ruído

2. **iPhone 17 Pro Max**
   - Smartphone premium com tecnologia de ponta

3. **MacBook Pro M5**
   - Notebook profissional com chip Apple Silicon

---

## ✨ Funcionalidades Implementadas

### 1. Sistema de Interação
- **Seleção de Objetos**: O usuário pode selecionar produtos apontando e clicando (com controlles)
- **Exclusividade de Seleção**: Apenas um produto pode estar selecionado por vez
- **Feedback Visual**: Produtos selecionados apresentam animações

### 2. Animações Dinâmicas
- **Flutuação**: Movimento suave de subida e descida (efeito float)
- **Rotação Automática**: Produto gira continuamente no eixo vertical
- **Sincronização**: Animações reiniciam do zero a cada nova seleção

### 3. Interface de Informações
- **Canvas 3D**: Interface 2D posicionada no espaço tridimensional
- **Semi-transparência**: Panel com transparência ajustável
- **Fade In/Out**: Transições suaves de aparecimento e desaparecimento
- **Billboard**: UI com informações sobre cada produto

### 4. Locomoção
- **Movimento Contínuo**: Opção de caminhada livre pelo ambiente

---

## 🥽 Demonstração Curta

![](catalog_vr_gif.gif)

## 🏗️ Arquitetura do Projeto

### Estrutura de Pastas

```
ProjetoVR/
├── Assets/
│   ├── Models/              # Modelos 3D dos produtos Apple (FBX)
│   ├── Scenes/
│   │   └── ProjectScene.unity
│   ├── Scripts/
│   │   ├── ProductInteractable.cs    # Lógica principal de interação
│   │   └── TechSpecsUI.cs            # Gerenciamento da UI
│   ├── VRTemplateAssets/    # Assets do template VR
│   ├── # Outras pastas padrões de projeto VR do Unity
└── Packages/               # Dependências e pacotes
```

### Scripts Principais

#### `ProductInteractable.cs`
Script responsável por toda a lógica de interação com os produtos:
- Gerenciamento de seleção/desseleção
- Animações de flutuação e rotação
- Controle de visibilidade da UI
- Sistema de fade in/out
- Integração com XR Grab Interactable

**Características técnicas:**
- Usa `XRGrabInteractable` para interações VR
- Implementa timer local para animações independentes
- Utiliza Coroutines para animações suaves
- Sistema estático para garantir exclusividade de seleção

#### `TechSpecsUI.cs`
Script auxiliar para gerenciamento da interface de especificações:
- Define nome e descrição dos produtos
- Permite customização do conteúdo

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

- **Unity Hub** instalado
- **Unity 6000.2.8f1** (versão recomendada)
- **Meta Quest 2** (ou outro dispositivo VR compatível com OpenXR)
- **App Meta Horizon** instalado no celular
- **SideQuest** instalado no PC ([Download aqui](https://sidequestvr.com/))
- **Cabo USB-C** para conectar o Quest ao PC
- Drivers VR atualizados

> **Nota**: Este tutorial é específico para Meta Quest 2, mas o procedimento é similar para outros dispositivos VR com pequenas adaptações nas configurações de build e conexão.

### Passos para Execução

1. **Clone o repositório**
   ```bash
   git clone https://github.com/Bidetti/ProjetoVR.git
   ```

2. **Abra o projeto no Unity Hub**
   - Adicione o projeto através do Unity Hub
   - Aguarde a importação dos assets e pacotes

3. **Configure o Build Profile para Meta Quest**
   - No Unity, vá em `File > Build Profiles`
   - Selecione **Meta Quest** na lista de plataformas
   - Clique em **Switch Profile** para habilitar a plataforma
   - Aguarde o Unity recompilar os assets para Android

4. **Habilite o Modo Desenvolvedor**
   - Abra o **app Meta Horizon** no seu celular
   - Navegue até as configurações do seu Quest
   - Ative o **Modo Desenvolvedor** (Developer Mode)
   - No **Meta Quest 2**, aceite a permissão quando solicitado

5. **Conecte o Meta Quest ao PC**
   - Conecte o **cabo USB-C** do Meta Quest ao seu PC
   - Coloque o headset e aceite a permissão de **depuração USB** quando aparecer
   - Mantenha o headset conectado durante o processo

6. **Verifique a conexão com SideQuest**
   - Abra o **SideQuest** no seu PC
   - Verifique se o **Oculus Quest 2** foi reconhecido (ícone verde no canto superior direito)
   - Se não for reconhecido:
     - Siga o passo a passo de configuração do SideQuest
     - Reinstale os drivers ADB se necessário
     - Tente desconectar e reconectar o cabo USB

7. **Build e Deploy no Meta Quest**
   - Volte ao Unity
   - Vá em `File > Build Profiles`
   - Clique em **Refresh** para que o Unity reconheça o Quest conectado
   - Verifique se o dispositivo aparece na lista
   - Clique em **Build And Run**
   - Escolha um local para salvar o APK (ou use o padrão)
   - Aguarde o build e a instalação automática no Quest

8. **Execute o projeto**
   - Após a instalação, o aplicativo será iniciado automaticamente no Quest
   - Você encontrará o app em **Biblioteca > Apps Desconhecidos** (Unknown Sources)
   - Use os controllers do Quest para interagir com os produtos

### Controles

- **Joystick/Touchpad**: Movimentação (se habilitado)
- **Trigger/Grip**: Selecionar produto
- **Joystick (clique)**: Ativar teleporte

---

## 🔮 Possíveis Melhorias Futuras

- [ ] Adicionar mais produtos ao catálogo
- [ ] Sistema de carrinho de compras virtual
- [ ] Integração com e-commerce real
- [ ] Comparação lado a lado de produtos
- [ ] Customização de cores/variantes dos produtos
- [ ] Sistema de reviews e avaliações em VR
- [ ] Multiplayer para compras compartilhadas
- [ ] Integração com IA para recomendações personalizadas

---

## 📄 Licença

Este projeto foi desenvolvido para fins educacionais como parte da disciplina **CIC904 - Multimídia e Realidade Virtual**.
