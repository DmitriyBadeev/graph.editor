import styled from 'styled-components'

export const Overlay = styled.div`
    position: fixed;
    background: rgba(0, 0, 0, .4);
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    overflow: auto;
    white-space: nowrap;
    text-align: center;

    &:before {
        content: '';
        display: inline-block;
        height: 80%;
        vertical-align: middle;
    }
`

export const ModalContainer = styled.div`    
    display: inline-block;
    vertical-align: middle;
    position: relative;
    white-space: normal;
    text-align: left;
    width: 512px;
    padding: 16px 32px;
    margin: 40px 5px;
    background: white;
    border-radius: 3px;
    box-shadow: 0 0 10px rgba(0, 0, 0, .1);
`

export const CrossIconContainer = styled.button`
    color: #808080;
    background: none;
    border: none;
    cursor: pointer;
    font-weight: 400;
    padding: 16px;
    font-size: 18px;
    position: absolute;
    top: 0;
    right: 0;

    &:hover {
        color: #333333;
    }
`

export const HeaderContainer = styled.div`
    padding: 10px 16px 16px 0;

    h3 {
        margin: 0;
    }
`

export const ContentContainer = styled.div`
    padding: 8px 0;
`

export const FooterContainer = styled.div`
    padding: 16px 0;
`