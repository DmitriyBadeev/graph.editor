import React from 'react'
import { Button, DEFAULT_THEME, Gapped, Tabs } from '@skbkontur/react-ui'
import { Sibebar } from './components/sidebar/Sidebar'
import { TypeGraph } from './components/graph/TypeGraph'
import { ElementGraph } from './components/graph/ElementGraph'
import { ThemeContext } from '@skbkontur/react-ui'
import styled, { createGlobalStyle } from 'styled-components'
import { QueryClient, QueryClientProvider } from 'react-query'
import { Title } from './components/typography/Title'
import { Divider } from './components/Divider'
import { useModal } from './components/modal/useModal'
import { AddElementModal } from './modals/AddElement' 
import { LinkTypeEditor } from './modals/LinkTypeEditor'

const GlobalStyle = createGlobalStyle`
  body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    box-sizing: border-box;
    margin: 0;
    padding: 0;
  }
`

const ContentContainer = styled.main`
    margin-left: 300px;
    padding: 40px 50px;
`

const ContentTab = styled.div`
    margin-top: 30px;
`

export const queryClient = new QueryClient()

export const App: React.FC = () => {
    const [graphId, setGraphId] = React.useState<string | null>(null)
    const [activeTab, setActiveTab] = React.useState<string>('types');
    const { modalComponent: AddElementModalComponent, open: openAddElementModal } = useModal(AddElementModal, { graphId })
    const { modalComponent: LinkTypeEditorComponent, open: openLinkTypeEditor } = useModal(LinkTypeEditor, { graphId })

    const selectGraph = (id: string) => setGraphId(id)
    const isNotSelected = !!graphId

    return (
        <ThemeContext.Provider value={DEFAULT_THEME}>
            <QueryClientProvider client={queryClient}>
                <GlobalStyle />
                <Sibebar selectGraph={selectGraph} activeGraphId={graphId} />
                {
                    isNotSelected && <ContentContainer>
                        <Tabs value={activeTab} onValueChange={setActiveTab}>
                            <Tabs.Tab id='types'>
                                Граф типов элементов
                            </Tabs.Tab>
                            <Tabs.Tab id='elements'>
                                Граф элементов
                            </Tabs.Tab>
                        </Tabs>

                        <ContentTab hidden={activeTab !== 'types'}>
                            <Title level={3}>Граф информационного взаимодействия типов элементов</Title>
                            <Divider />
                            <Gapped vertical>
                                <TypeGraph graphId={graphId}/>
                                <Button onClick={openLinkTypeEditor}>Редактирование связей</Button>
                            </Gapped>
                        </ContentTab>
                        
                        <ContentTab hidden={activeTab !== 'elements'}>
                            <Title level={3}>Граф информационного взаимодействия элементов</Title>
                            <Divider />
                            <Gapped vertical>
                                <ElementGraph graphId={graphId}/>
                                <Button onClick={openAddElementModal}>Добавление</Button>
                            </Gapped>
                        </ContentTab>

                        {AddElementModalComponent}
                        {LinkTypeEditorComponent}
                    </ContentContainer>
                }
            </QueryClientProvider>
        </ThemeContext.Provider>
    );
}

export default App;
