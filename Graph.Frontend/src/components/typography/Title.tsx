import React from 'react'
import styled, { css } from 'styled-components'

type PropTypes = {
    level: 1 | 2 | 3;
}

const StyledTitle = css`
    color: #333;
    margin: 0 0 15px 0;
`

const FirstTitle = styled.h1`
    font-size: 32px;
    ${StyledTitle}
`

const SecondTitle = styled.h2`
    font-size: 28px;
    ${StyledTitle}
`

const ThirdTitle = styled.h3`
    font-size: 24px;
    ${StyledTitle}
`

export const Title: React.FC<PropTypes> = ({ level = 2, children }) => {

    if (level === 1) {
        return <FirstTitle>{children}</FirstTitle>
    }

    if (level === 3) {
        return <ThirdTitle>{children}</ThirdTitle>
    }

    return <SecondTitle>{children}</SecondTitle>
}