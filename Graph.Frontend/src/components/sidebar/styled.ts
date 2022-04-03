import styled from "styled-components"

export const SidebarContainer = styled.aside`
    position: fixed;
    left: 0;
    top: 0;
    width: 300px;
    height: 100vh;
    border-right: solid 1px #eee;
    box-shadow: 0 0 5px rgba(0,0,0,.1);
    padding: 30px 20px;
    box-sizing: border-box;
`

export const ListGraphContainer = styled.div`
    
`

export const GraphItem = styled.div<{active: boolean}>`
    padding: 10px;
    cursor: pointer;
    border-radius: 3px;
    background: ${props => props.active ? '#f5f5f5' : 'white'};

    &:hover {
        background: #eee;
    }
`